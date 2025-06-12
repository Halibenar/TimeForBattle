using System.Windows.Input;
using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

public partial class CreatureListViewModel: BaseViewModel
{
    public CreatureService<Creature> creatureService;
    public ObservableCollection<Creature> Creatures { get; } = new();
    public ObservableCollection<Creature> Initiative { get; } = new();

    public CreatureListViewModel(CreatureService<Creature> characterService)
    {
        Title = "Creatures";
        this.creatureService = characterService;
        Creatures = [];
        TestCharacters();
        RefreshCreatures();
    }

    public async void TestCharacters()
    {
        //Creature characterA = new Creature();
        //characterA.Name = "Martijn";
        //characterA.Initiative = 25;
        //characterA.Bonus = 9;
        //characterA.Type = "DM";
        //characterA.MaximumHP = 99;
        //characterA.CurrentHP = 99;

        //await creatureService.SaveAsync(characterA);

        //Creature characterB = new Creature();
        //characterB.Name = "Rita";
        //characterB.Initiative = 25;
        //characterB.Bonus = 9;
        //characterB.Type = "Monster";
        //characterB.MaximumHP = 50;
        //characterB.CurrentHP = 50;

        //await creatureService.SaveAsync(characterB);

        //Creature characterC = new Creature();
        //characterC.Name = "Robert";
        //characterC.Initiative = 15;
        //characterC.Bonus = 5;
        //characterC.Type = "Player";
        //characterC.MaximumHP = 30;
        //characterC.CurrentHP = 30;

        //await creatureService.SaveAsync(characterC);
    }

    [ObservableProperty] bool isRefreshing;

    [RelayCommand]
    public async Task RefreshCreatures()
    {
        List<Creature> creatureData = await creatureService.GetAllAsync();

        Creatures.Clear();
        foreach (Creature creature in creatureData)
        {
            Creatures.Add(creature);
        }
    }

    [RelayCommand]
    public async Task AddToInitiativeAsync(Creature creature)
    {
        Initiative.Add(creature);
    }

    [RelayCommand]
    public async Task RemoveFromInitiativeAsync(Creature creature)
    {
        Initiative.Remove(creature);
    }

    [RelayCommand]
    async Task DeleteCreature(Creature creature)
    {
        if (await creatureService.DeleteAsync(await creatureService.GetByIdAsync(creature.Id)) > 0)
        {
            Creatures.Remove(creature);
        }
    }

    [RelayCommand]
    async Task UpdateCreature(Creature creature)
    {
        await AppShell.Current.Navigation.PushAsync(new View.AddCreaturePage());
    }

    [RelayCommand]
    void RollInitiative()
    {
        Random rng = new Random();

        Parallel.ForEach(Creatures, creature =>
        {
            //if (character.Type == "NPC")
            
                int initiative = rng.Next(1, 21) + creature.Bonus;
                creature.Initiative = initiative;
                creatureService.SaveAsync(creature);
            
        });

        SortInitiative();
    }

    [RelayCommand]
    void SortInitiative()
    {
        var sortedCreatures = Creatures.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.Bonus).ToList();

        Creatures.Clear();
        foreach (var creature in sortedCreatures)
        {
            Creatures.Add(creature);
        }
    }
}

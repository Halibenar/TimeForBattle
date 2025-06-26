using System.Windows.Input;
using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

public partial class CreatureListViewModel : BaseViewModel
{
    public CreatureService<Creature> creatureService;
    public CreatureService<InitiativeCreature> initiativeService;

    public ObservableCollection<Creature> Creatures { get; } = new();
    public ObservableCollection<Creature> Monsters { get; } = new();
    public ObservableCollection<Creature> Players { get; } = new();
    public ObservableCollection<InitiativeCreature> Initiative { get; } = new();

    public bool ViewMonsters;

    public CreatureListViewModel(CreatureService<Creature> creatureService, CreatureService<InitiativeCreature> initiativeService)
    {
        Title = "Creatures";
        this.creatureService = creatureService;
        this.initiativeService = initiativeService;
        Creatures = [];
        Monsters = [];
        Players = [];
        Initiative = [];
        ViewMonsters = true;
        RefreshCreaturesCommand.Execute(null);
    }

    [ObservableProperty] bool isRefreshing;

    [RelayCommand]
    public async Task RefreshCreatures()
    {
        List<Creature> creatureData = await creatureService.GetAllAsync();
        Creatures.Clear();
        Monsters.Clear();
        Players.Clear();
        foreach (Creature creature in creatureData)
        {
            if (creature.IsPlayer)
            {
                Players.Add(creature);
                if (!ViewMonsters)
                    Creatures.Add(creature);
            }

            else
            {
                Monsters.Add(creature);
                if (ViewMonsters)
                    Creatures.Add(creature);
            }
        }

        List<InitiativeCreature> initiativeCreatureData = await initiativeService.GetAllAsync();
        Initiative.Clear();
        foreach (InitiativeCreature initiativeCreature in initiativeCreatureData)
        {
            Initiative.Add(initiativeCreature);
        }
    }

    [RelayCommand]
    public async Task ChangeViewAsync(bool viewMonsters)
    {
        ViewMonsters = viewMonsters;
        await RefreshCreatures();
    }

    [RelayCommand]
    public async Task GoToDetailsAsync(Creature creature)
    {
        if (creature is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(CreatureDetailsPage)}", true,
            new Dictionary<string, object>
            {
                {"Creature", creature}
            });
    }

    [RelayCommand]
    public async Task GoToInitiativeAsync()
    {
        if (this.Initiative is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(InitiativePage)}", true);
    }

    [RelayCommand]
    public async Task AddToInitiativeAsync(Creature creature)
    {
        if (creature is null)
            return;

        InitiativeCreature initiativeCreature = new(creature);

        await initiativeService.SaveAsync(initiativeCreature);

        Initiative.Add(initiativeCreature);
    }

    [RelayCommand]
    public async Task RemoveFromInitiativeAsync(InitiativeCreature initiativeCreature)
    {
        if (initiativeCreature is null)
            return;

        if (await initiativeService.DeleteAsync(await initiativeService.GetByIdAsync(initiativeCreature.Id)) > 0)
        {
            Initiative.Remove(initiativeCreature);
        }
    }

    [RelayCommand]
    async Task DeleteCreature(Creature creature)
    {
        if (await creatureService.DeleteAsync(await creatureService.GetByIdAsync(creature.Id)) > 0)
        {
            if (creature.IsPlayer)
                Players.Remove(creature);
            else
                Monsters.Remove(creature);
        }
    }

    [RelayCommand]
    public async Task NewMonsterAsync()
    {
        Creature creature = new()
        {
            IsPlayer = false
        };

        await Shell.Current.GoToAsync($"{nameof(AddCreaturePage)}", true,
            new Dictionary<string, object>
            {
                {"Creature", creature}
            });
    }

    [RelayCommand]
    public async Task NewPlayerAsync()
    {
        Creature creature = new()
        {
            IsPlayer = true
        };

        await Shell.Current.GoToAsync($"{nameof(AddCreaturePage)}", true,
            new Dictionary<string, object>
            {
                {"Creature", creature}
            });
    }

    [RelayCommand]
    public async Task<Creature> GetCreature(int iD)
    {
        return await creatureService.GetByIdAsync(iD);
    }

    [RelayCommand]
    void RollInitiative()
    {
        //Random rng = new Random();

        //Parallel.ForEach(Initiative, creature =>
        //{
        //    //if (character.Type == "NPC")

        //        int initiative = rng.Next(1, 21) + creature.InitiativeBonus;
        //        creature.Initiative = initiative;
        //        creatureService.SaveAsync(creature);

        //});

        //SortInitiative();
    }

    [RelayCommand]
    void SortInitiative()
    {
        //    var sortedCreatures = Creatures.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.Bonus).ToList();

        //    Creatures.Clear();
        //    foreach (var creature in sortedCreatures)
        //    {
        //        Creatures.Add(creature);
        //    }
    }
}

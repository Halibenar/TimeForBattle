using System.Windows.Input;
using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

public partial class CreatureListViewModel: BaseViewModel
{
    public CreatureService<Creature> creatureService;
    public CreatureService<InitiativeCreature> initiativeService;

    public ObservableCollection<Creature> Creatures { get; } = new();
    public ObservableCollection<InitiativeCreature> Initiative { get; } = new();

    public CreatureListViewModel(CreatureService<Creature> creatureService, CreatureService<InitiativeCreature> initiativeService)
    {
        Title = "Creatures";
        this.creatureService = creatureService;
        this.initiativeService = initiativeService;
        Creatures = [];
        Initiative = [];
        TestCreatures();
        RefreshCreaturesCommand.Execute(null);
    }

    public async void TestCreatures()
    {
        //Creature newCreature = new()
        //{
        //    Name = "Goblin Warrior",
        //    Size = "Small",
        //    Type = "Fey (Goblinoid)",
        //    Alignment = "Chaotic Neutral",
        //    ArmorClass = 15,
        //    InitiativeBonus = 2,
        //    MaximumHitPoints = 10,
        //    Speed = "30 ft.",
        //    StrScore = 8,
        //    DexScore = 15,
        //    ConScore = 10,
        //    IntScore = 10,
        //    WisScore = 8,
        //    ChaScore = 8,
        //    ChallengeRating = "1/4"
        //};

        //await creatureService.SaveAsync(newCreature);

        //Creature newCreature2 = new()
        //{
        //    Name = "Kobold Warrior",
        //    Size = "Small",
        //    Type = "Dragon",
        //    Alignment = "Neutral",
        //    ArmorClass = 14,
        //    InitiativeBonus = 2,
        //    MaximumHitPoints = 7,
        //    Speed = "30 ft.",
        //    StrScore = 7,
        //    DexScore = 15,
        //    ConScore = 9,
        //    IntScore = 8,
        //    WisScore = 7,
        //    ChaScore = 8,
        //    ChallengeRating = "1/8"
        //};

        //await creatureService.SaveAsync(newCreature2);

        //Creature newCreature3 = new()
        //{
        //    Name = "Shadow",
        //    Size = "Medium",
        //    Type = "Undead",
        //    Alignment = "Chaotic Evil",
        //    ArmorClass = 12,
        //    InitiativeBonus = 2,
        //    MaximumHitPoints = 27,
        //    Speed = "40 ft.",
        //    StrScore = 6,
        //    DexScore = 14,
        //    ConScore = 13,
        //    IntScore = 6,
        //    WisScore = 10,
        //    ChaScore = 8,
        //    ChallengeRating = "1/2",
        //    Senses = "Sarkvision 60 ft."
        //};

        //await creatureService.SaveAsync(newCreature3);
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

        List<InitiativeCreature> initiativeCreatureData = await initiativeService.GetAllAsync();
        Initiative.Clear();
        foreach(InitiativeCreature initiativeCreature in initiativeCreatureData)
        {
            Initiative.Add(initiativeCreature);
        }
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
            Creatures.Remove(creature);
        }
    }

    //[RelayCommand]
    //async Task UpdateCreature(Creature creature)
    //{
    //    await AppShell.Current.Navigation.PushAsync(new View.AddCreaturePage());
    //}

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

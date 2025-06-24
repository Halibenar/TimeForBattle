using System.Windows.Input;
using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

public partial class CreatureListViewModel : BaseViewModel
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

        //Creature newCreature4 = new()
        //{
        //    Name = "Lich",
        //    Size = "Medium",
        //    Type = "Undead (Wizard)",
        //    Alignment = "Neutral Evil",
        //    ArmorClass = 20,
        //    InitiativeBonus = 17,
        //    MaximumHitPoints = 315,
        //    Speed = "30 ft.",
        //    StrScore = 11,
        //    DexScore = 16,
        //    ConScore = 16,
        //    IntScore = 21,
        //    WisScore = 14,
        //    ChaScore = 16,
        //    ChallengeRating = "21",

        //    SavingThrows = "Dex +7, Con +7, Int +7, Wis +7",
        //    Skills = "Arcana +19, History +12, Insight +9, Perception +9",
        //    Resistances = "Cold, Lightning",
        //    //Vulnerabilities = "",
        //    Immunities = "Necrotic, Poison; Charmed, Exhaustion, Frightened, Paralyzed, Poisoned",
        //    Senses = "Truesight 120 ft.; Passive Perception 19",
        //    Languages = "All",
        //    Gear = "Component Pouch",

        //    Traits = "Legendary Resistance (4/Day, or 5/Day in Lair). If the lich fails a saving throw, it can choose to succeed instead.\r\n\r\nSpirit Jar. If destroyed, the lich reforms in 1d10 days if it has a spirit jar, reviving with all its Hit Points. The new body appears in an unoccupied space within the lich’s lair.",

        //    Actions = "Multiattack. The lich makes three attacks, using Eldritch Burst or Paralyzing Touch in any combination.\r\n\r\nEldritch Burst. Melee or Ranged Attack Roll: +12, reach 5 ft. or range 120 ft. Hit: 31 (4d12 + 5) Force damage.\r\n\r\nParalyzing Touch. Melee Attack Roll: +12, reach 5 ft. Hit: 15 (3d6 + 5) Cold damage, and the target has the Paralyzed condition until the start of the lich’s next turn.\r\n\r\nSpellcasting. The lich casts one of the following spells, using Intelligence as the spellcasting ability (spell save DC 20):\r\n\r\nAt Will: Detect Magic, Detect Thoughts, Dispel Magic, Fireball (level 5 version), Invisibility, Lightning Bolt (level 5 version), Mage Hand, Prestidigitation\r\n\r\n2/Day Each: Animate Dead, Dimension Door, Plane Shift\r\n\r\n1/Day Each: Chain Lightning, Finger of Death, Power Word Kill, Scrying",
        //    //BonusActions = "",
        //    Reactions = "Protective Magic. The lich casts Counterspell or Shield in response to the spell’s trigger, using the same spellcasting ability as Spellcasting.",
        //    LegendaryActions = "Legendary Action Uses: 3 (4 in Lair). Immediately after another creature’s turn, the lich can expend a use to take one of the following actions. The lich regains all expended uses at the start of each of its turns.\r\n\r\nDeathly Teleport. The lich teleports up to 60 feet to an unoccupied space it can see, and each creature within 10 feet of the space it left takes 11 (2d10) Necrotic damage.\r\n\r\nDisrupt Life. Constitution Saving Throw: DC 20, each creature that isn’t an Undead in a 20-foot Emanation originating from the lich. Failure: 31 (9d6) Necrotic damage. Success: Half damage. Failure or Success: The lich can’t take this action again until the start of its next turn.\r\n\r\nFrightening Gaze. The lich casts Fear, using the same spellcasting ability as Spellcasting. The lich can’t take this action again until the start of its next turn.",
        //};

        //await creatureService.SaveAsync(newCreature4);
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
        foreach (InitiativeCreature initiativeCreature in initiativeCreatureData)
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

    [RelayCommand]
    public async Task NewCreatureAsync()
    {
        Creature creature = new();

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

using System.ComponentModel.Design;
using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

[QueryProperty("Combat", "Combat")]
public partial class CreatureListViewModel : BaseViewModel
{
    [ObservableProperty] public ObservableCollection<Creature> creatures = new();
    public CreatureService<Creature> CreatureService;
    public InitiativeService<InitiativeCreature> InitiativeService;
    
    public ObservableCollection<Creature> Monsters { get; }
    public ObservableCollection<Creature> Players { get; }
    public ObservableCollection<InitiativeCreature> Initiative { get; }

    public bool ViewMonsters;
    [ObservableProperty] public Combat combat;

    public CreatureListViewModel(CreatureService<Creature> creatureService, InitiativeService<InitiativeCreature> initiativeService)
    {
        Title = "Creatures";
        this.CreatureService = creatureService;
        this.InitiativeService = initiativeService;
        Creatures = [];
        Monsters = [];
        Players = [];
        Initiative = [];
        ViewMonsters = true;
    }

    [ObservableProperty] bool isRefreshing;

    [RelayCommand]
    public async Task RefreshCreatures()
    {
        List<Creature> creatureData = await CreatureService.GetAllAsync();
        Creatures.Clear();
        Monsters.Clear();
        Players.Clear();

        foreach (Creature creature in creatureData)
        {
            if (creature.IsPlayer)
                Players.Add(creature);
            else
                Monsters.Add(creature);
        }

        List<InitiativeCreature> initiativeCreatureData = await InitiativeService.GetAllByCombatAsync(Combat.Id);
        Initiative.Clear();

        foreach (InitiativeCreature initiativeCreature in initiativeCreatureData)
        {
            Initiative.Add(initiativeCreature);
        }

        await Task.Run(() => ChangeView(ViewMonsters));
    }

    [RelayCommand]
    public void ChangeView(bool viewMonsters)
    {
        ViewMonsters = viewMonsters;

        if (ViewMonsters)
            Creatures = Monsters;
        else
            Creatures = Players;
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

        await Shell.Current.GoToAsync($"{nameof(InitiativePage)}", true,
            new Dictionary<string, object>
            {
                {"Combat", Combat}
            });
    }

    [RelayCommand]
    public async Task AddToInitiativeAsync(Creature creature)
    {
        if (creature is null)
            return;

        InitiativeCreature newInitiativeCreature = new(creature, Combat.Id);

        int identifier = 1;
        foreach(InitiativeCreature initiativeCreature in Initiative) {
            if (initiativeCreature.CreatureID == newInitiativeCreature.CreatureID)
            {
                if (initiativeCreature.NameID is null)
                {
                    initiativeCreature.NameID = identifier;
                    await InitiativeService.SaveAsync(initiativeCreature);
                    identifier++;
                }
                else
                {
                    identifier = (int)initiativeCreature.NameID + 1;
                }
            }
        }

        if (identifier > 1)
            newInitiativeCreature.NameID = identifier;

        await InitiativeService.SaveAsync(newInitiativeCreature);

        Initiative.Add(newInitiativeCreature);
    }

    [RelayCommand]
    public async Task RemoveFromInitiativeAsync(InitiativeCreature initiativeCreature)
    {
        if (initiativeCreature is null)
            return;

        if (await InitiativeService.DeleteAsync(await InitiativeService.GetByIdAsync(initiativeCreature.Id)) > 0)
        {
            Initiative.Remove(initiativeCreature);
        }
    }

    [RelayCommand]
    public async Task NewCreatureAsync(bool isPlayer)
    {
        Creature creature = new()
        {
            IsPlayer = isPlayer
        };

        await Shell.Current.GoToAsync($"{nameof(AddCreaturePage)}", true,
            new Dictionary<string, object>
            {
                {"Creature", creature}
            });
    }
}

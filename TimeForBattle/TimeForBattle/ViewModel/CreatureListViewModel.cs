using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

public partial class CreatureListViewModel : BaseViewModel
{
    [ObservableProperty] public ObservableCollection<Creature> creatures = new();
    public CreatureService<Creature> CreatureService;
    public CreatureService<InitiativeCreature> InitiativeService;
    
    public ObservableCollection<Creature> Monsters { get; }
    public ObservableCollection<Creature> Players { get; }
    public ObservableCollection<InitiativeCreature> Initiative { get; }

    public bool ViewMonsters;

    public CreatureListViewModel(CreatureService<Creature> creatureService, CreatureService<InitiativeCreature> initiativeService)
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

        List<InitiativeCreature> initiativeCreatureData = await InitiativeService.GetAllAsync();
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

        await Shell.Current.GoToAsync($"{nameof(InitiativePage)}", true);
    }

    [RelayCommand]
    public async Task AddToInitiativeAsync(Creature creature)
    {
        if (creature is null)
            return;

        InitiativeCreature initiativeCreature = new(creature);

        await InitiativeService.SaveAsync(initiativeCreature);

        Initiative.Add(initiativeCreature);
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
    async Task DeleteCreature(Creature creature)
    {
        if (await CreatureService.DeleteAsync(await CreatureService.GetByIdAsync(creature.Id)) > 0)
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
        return await CreatureService.GetByIdAsync(iD);
    }
}

using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

public partial class InitiativeViewModel : BaseViewModel
{
    public CreatureService<InitiativeCreature> InitiativeService;
    [ObservableProperty] public ObservableCollection<InitiativeCreature> initiative = new();

    public InitiativeViewModel(CreatureService<InitiativeCreature> initiativeService)
    {
        this.InitiativeService = initiativeService;
        Initiative = [];
    }

    [RelayCommand]
    public async Task RefreshInitiative()
    {
        List<InitiativeCreature> initiativeCreatureData = await InitiativeService.GetAllAsync();
        Initiative.Clear();

        foreach (InitiativeCreature initiativeCreature in initiativeCreatureData)
        {
            Initiative.Add(initiativeCreature);
        }
    }

    [RelayCommand]
    void RollInitiative()
    {
        Random rng = new();

        foreach(InitiativeCreature creature in Initiative)
        {
            if (!creature.IsPlayer)
            {
                int initiative = rng.Next(1, 21) + creature.InitiativeBonus;
                creature.Initiative = initiative;
                Task.Run(() => InitiativeService.SaveAsync(creature));
            }

        }

        SortInitiative();
    }

    [RelayCommand]
    public void SortInitiative()
    {
        var sortedCreatures = Initiative.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.InitiativeBonus).ToList();

        Initiative.Clear();
        foreach (var creature in sortedCreatures)
        {
            Initiative.Add(creature);
        }
    }
}

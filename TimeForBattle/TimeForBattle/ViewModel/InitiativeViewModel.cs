using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

public partial class InitiativeViewModel : BaseViewModel
{
    public CreatureService<InitiativeCreature> InitiativeService;
    public ObservableCollection<InitiativeCreature> Initiative { get; }

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
}

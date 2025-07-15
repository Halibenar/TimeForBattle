using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

public partial class CombatListViewModel : BaseViewModel
{
    public CreatureService<Combat> CombatService;
    public ObservableCollection<Combat> Combats { get; }
    [ObservableProperty] bool isRefreshing;

    public CombatListViewModel(CreatureService<Combat> combatService)
    {
        Title = "Load Combat";
        this.CombatService = combatService;
        Combats = [];
    }

    [RelayCommand]
    public async Task RefreshCombats()
    {
        List<Combat> combatData = await CombatService.GetAllAsync();
        Combats.Clear();

        foreach (Combat combat in combatData)
        {
            Combats.Add(combat);
        }
    }

    [RelayCommand]
    public async Task DeleteCombatAsync(Combat combat)
    {
        if (combat is null)
            return;

        await CombatService.DeleteAsync(combat);

        //also delete creatures in initiative for that combat?

        await RefreshCombats();
    }

    [RelayCommand]
    public async Task LoadCombatAsync(Combat combat)
    {
        if (combat is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(InitiativePage)}", true,
            new Dictionary<string, object>
            {
                {"Combat", combat}
            });
    }
}

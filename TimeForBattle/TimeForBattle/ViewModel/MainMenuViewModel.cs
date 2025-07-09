using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

public partial class MainMenuViewModel : BaseViewModel
{
    public CreatureService<Combat> CombatService;
    public ObservableCollection<Combat> Combats { get; }
    [ObservableProperty] public string newCombatName;

    public MainMenuViewModel(CreatureService<Combat> combatService)
    {
        Title = "Main Menu";
        this.CombatService = combatService;
        Combats = [];
    }

    [ObservableProperty] bool isRefreshing;

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
    public async Task NewCombat(string name)
    {
        Combat combat = new();

        Combats.Add(combat);
        await CombatService.SaveAsync(combat);

        if (String.IsNullOrEmpty(newCombatName))
            combat.Name = "Combat #" + combat.Id.ToString();
        else
            combat.Name = NewCombatName;
        await CombatService.SaveAsync(combat);

        await Shell.Current.GoToAsync($"{nameof(InitiativePage)}", true,
            new Dictionary<string, object>
            {
                {"Combat", combat}
            });
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

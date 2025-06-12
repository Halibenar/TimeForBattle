namespace TimeForBattle.ViewModel;

[QueryProperty("Creature", "Creature")]
public partial class CreatureDetailsViewModel: BaseViewModel
{
    public CreatureDetailsViewModel()
    {

    }

    [ObservableProperty] Creature creature;
}

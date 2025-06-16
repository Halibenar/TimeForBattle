namespace TimeForBattle.ViewModel;

public partial class InitiativeViewModel : BaseViewModel
{
    public InitiativeViewModel()
    {

    }

    [ObservableProperty] List<Creature> initiative;
}

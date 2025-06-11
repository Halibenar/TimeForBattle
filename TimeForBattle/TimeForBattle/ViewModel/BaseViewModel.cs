namespace TimeForBattle.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel()
    {

    }

    [ObservableProperty] bool isBusy;
    [ObservableProperty] string title;
}
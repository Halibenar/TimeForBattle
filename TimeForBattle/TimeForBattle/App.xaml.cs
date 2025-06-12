namespace TimeForBattle;

public partial class App : Application
{
    public static ViewModel.CreatureListViewModel? InitiativeViewModel { get; private set; }

    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
namespace TimeForBattle;

public partial class App : Application
{
    public static ViewModel.CharactersViewModel? InitiativeViewModel { get; private set; }

    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
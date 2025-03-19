namespace TimeForBattle
{
    public partial class App : Application
    {
        public static ViewModels.InitiativeViewModel? InitiativeViewModel { get; private set; }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

            InitiativeViewModel = new();
            InitiativeViewModel.RefreshCharacters().ContinueWith((s) => { });

            return window;
        }
    }
}
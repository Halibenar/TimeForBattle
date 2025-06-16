using TimeForBattle.View;

namespace TimeForBattle;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CreatureDetailsPage), typeof(CreatureDetailsPage));
        Routing.RegisterRoute(nameof(InitiativePage), typeof(InitiativePage));
    }
}

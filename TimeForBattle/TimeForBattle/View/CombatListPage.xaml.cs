namespace TimeForBattle.View;

public partial class CombatListPage : ContentPage
{
    CombatListViewModel viewModel;

    public CombatListPage(CombatListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
    }

    protected async override void OnAppearing()
    {
        await viewModel.RefreshCombats();
    }
}
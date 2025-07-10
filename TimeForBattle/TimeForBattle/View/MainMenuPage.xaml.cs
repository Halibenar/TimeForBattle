namespace TimeForBattle.View;

public partial class MainMenuPage : ContentPage
{
	MainMenuViewModel viewModel;

	public MainMenuPage(MainMenuViewModel viewModel)
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
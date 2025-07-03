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

    protected override void OnAppearing()
    {
        viewModel.RefreshCombats();
    }
}
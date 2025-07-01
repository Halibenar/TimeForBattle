namespace TimeForBattle.View;

public partial class InitiativePage : ContentPage
{
	InitiativeViewModel viewModel;

	public InitiativePage(InitiativeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        viewModel.RefreshInitiative();
    }

    private void Entry_TextCompleted(object sender, EventArgs e)
    {
        viewModel.SortInitiative();
    }
}
namespace TimeForBattle.View;

public partial class CreatureListPage : ContentPage
{
	CreatureListViewModel viewModel;

    public CreatureListPage(CreatureListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;

    }

    protected override void OnAppearing()
	{
		viewModel.RefreshCreatures();
	}
}
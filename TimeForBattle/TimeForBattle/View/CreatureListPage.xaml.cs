namespace TimeForBattle.View;

public partial class CreatureListPage : ContentPage
{
    public CreatureListPage(CreatureListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
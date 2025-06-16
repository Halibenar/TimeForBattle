namespace TimeForBattle.View;

public partial class InitiativePage : ContentPage
{
	public InitiativePage(CreatureListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
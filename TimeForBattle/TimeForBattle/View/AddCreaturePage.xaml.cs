namespace TimeForBattle.View;

public partial class AddCreaturePage : ContentPage
{
	public AddCreaturePage(AddCreatureViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
namespace TimeForBattle.View;

public partial class CreatureDetailsPage : ContentPage
{
    public CreatureDetailsPage(CreatureDetailsViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }
}
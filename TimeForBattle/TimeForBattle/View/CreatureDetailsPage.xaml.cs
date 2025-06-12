namespace TimeForBattle.View;

public partial class CreatureDetailsPage : ContentPage
{
	public CreatureDetailsPage(CreatureDetailsViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
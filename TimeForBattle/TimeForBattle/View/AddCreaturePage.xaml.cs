namespace TimeForBattle.View;

public partial class AddCreaturePage : ContentPage
{
	public AddCreaturePage(AddCreatureViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
namespace TimeForBattle.View;

public partial class AddCreaturePage : ContentPage
{
	public AddCreaturePage()
	{
		InitializeComponent();
		this.BindingContext = new ViewModel.AddCreatureViewModel();
	}

    public AddCreaturePage(ViewModel.CreatureDetailsViewModel creature)
    {
        InitializeComponent();
        this.BindingContext = new ViewModel.AddCreatureViewModel();
    }
}
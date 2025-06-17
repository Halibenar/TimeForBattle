namespace TimeForBattle.View;

public partial class CreatureDetailsPage : ContentPage
{
    CreatureDetailsViewModel viewModel;

    public CreatureDetailsPage(CreatureDetailsViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
        this.viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        this.viewModel.RefreshCommand.Execute(null);
    }
}
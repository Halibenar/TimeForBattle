namespace TimeForBattle.View;

public partial class CharacterPage : ContentPage
{
	public CharacterPage(CharacterDetailsViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}
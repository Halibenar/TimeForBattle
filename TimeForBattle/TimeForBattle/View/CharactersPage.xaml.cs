namespace TimeForBattle.View;

public partial class CharactersPage : ContentPage
{
	public CharactersPage(CharactersViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
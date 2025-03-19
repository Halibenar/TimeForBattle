namespace TimeForBattle.Views;

public partial class CharacterPage : ContentPage
{
	public CharacterPage()
	{
		BindingContext = App.InitiativeViewModel?.SelectedCharacter;
		InitializeComponent();
	}
}
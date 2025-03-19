namespace TimeForBattle.Views;

public partial class InitiativePage : ContentPage
{
	public InitiativePage()
	{
		InitializeComponent();
	}

	private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		await Navigation.PushAsync(new Views.CharacterPage());
	}

    private void addCharacterButton_Clicked(object sender, EventArgs e)
    {

    }
}
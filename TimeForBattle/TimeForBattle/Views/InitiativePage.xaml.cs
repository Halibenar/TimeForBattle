using System.Threading.Tasks;

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

    private async void addCharacterButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Views.AddCharacterPage());
    }
}
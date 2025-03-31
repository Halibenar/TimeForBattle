namespace TimeForBattle.Views;

public partial class AddCharacterPage : ContentPage
{
	public AddCharacterPage()
	{
		InitializeComponent();
		this.BindingContext = new ViewModels.AddCharacterViewModel();
	}

    public AddCharacterPage(ViewModels.CharacterViewModel character)
    {
        InitializeComponent();
        this.BindingContext = new ViewModels.AddCharacterViewModel(character);
    }
}
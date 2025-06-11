namespace TimeForBattle.View;

public partial class AddCharacterPage : ContentPage
{
	public AddCharacterPage()
	{
		InitializeComponent();
		this.BindingContext = new ViewModel.AddCharacterViewModel();
	}

    public AddCharacterPage(ViewModel.CharacterDetailsViewModel character)
    {
        InitializeComponent();
        this.BindingContext = new ViewModel.AddCharacterViewModel();
    }
}
namespace TimeForBattle.ViewModel;

[QueryProperty("Character", "Character")]
public partial class CharacterDetailsViewModel: BaseViewModel
{
    public CharacterDetailsViewModel()
    {

    }

    [ObservableProperty] Character character;
}

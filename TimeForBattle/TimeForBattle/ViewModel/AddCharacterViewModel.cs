using System.Windows.Input;

namespace TimeForBattle.ViewModel;

class AddCharacterViewModel : BaseViewModel
{
    //private int Id;
    //private string _characterName;
    //private int _characterBonus;
    //private string _characterType;
    //private int _characterMaximumHP;
    //private int _characterCurrentHP;

    //public int CharacterId {
    //    get { return Id; }
    //    set { SetProperty(ref Id, value); }
    //}
    //public string CharacterName {
    //    get { return _characterName; }
    //    set { SetProperty(ref _characterName, value); }
    //}
    //public int CharacterBonus {
    //    get { return _characterBonus; }
    //    set { SetProperty(ref _characterBonus, value); }
    //}
    //public string CharacterType
    //{
    //    get { return _characterType; }
    //    set { SetProperty(ref _characterType, value); }
    //}
    //public int CharacterMaximumHP
    //{
    //    get { return _characterMaximumHP; }
    //    set { SetProperty(ref _characterMaximumHP, value); }
    //}
    //public int CharacterCurrentHP
    //{
    //    get { return _characterCurrentHP; }
    //    set { SetProperty(ref _characterCurrentHP, value); }
    //}

    //private Services.CharacterService database;

    //public AddCharacterViewModel()
    //{
    //    database = new Services.CharacterService();
    //}

    //public AddCharacterViewModel(ViewModel.CharacterDetailsViewModel character)
    //{
    //    CharacterId = character.CharacterId;
    //    CharacterName = character.CharacterName;
    //    CharacterBonus = character.CharacterBonus;
    //    CharacterType = character.CharacterType;
    //    CharacterMaximumHP = character.CharacterMaximumHP;
    //    CharacterCurrentHP = character.CharacterCurrentHP;
    //    database = new Services.CharacterService();
    //}

    //public ICommand AddCharacterCommand => new Command(async () =>
    //{
    //    Model.Character character = new Model.Character
    //    {
    //        CharacterId = CharacterId,
    //        Name = CharacterName,
    //        Bonus = CharacterBonus,
    //        Type = CharacterType,
    //        CurrentHP = CharacterCurrentHP,
    //        MaximumHP = CharacterMaximumHP
    //    };
    //    await database.SaveCharacterAsync(character);
    //    await ViewModel.CharactersViewModel.RefreshCharacters();
    //    //await AppShell.Current.Navigation.PushAsync(App.InitiativeViewModel);
    //});
}

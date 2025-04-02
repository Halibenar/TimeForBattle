using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TimeForBattle.ViewModels
{
    class AddCharacterViewModel : ObservableObject
    {
        private int _characterId;
        private string _characterName;
        private int _characterBonus;
        private string _characterType;
        private int _characterMaximumHP;
        private int _characterCurrentHP;

        public int CharacterId {
            get { return _characterId; }
            set { SetProperty(ref _characterId, value); }
        }
        public string CharacterName {
            get { return _characterName; }
            set { SetProperty(ref _characterName, value); }
        }
        public int CharacterBonus {
            get { return _characterBonus; }
            set { SetProperty(ref _characterBonus, value); }
        }
        public string CharacterType
        {
            get { return _characterType; }
            set { SetProperty(ref _characterType, value); }
        }
        public int CharacterMaximumHP
        {
            get { return _characterMaximumHP; }
            set { SetProperty(ref _characterMaximumHP, value); }
        }
        public int CharacterCurrentHP
        {
            get { return _characterCurrentHP; }
            set { SetProperty(ref _characterCurrentHP, value); }
        }

        private Models.CharactersDatabase database;

        public AddCharacterViewModel()
        {
            database = new Models.CharactersDatabase();
        }

        public AddCharacterViewModel(ViewModels.CharacterViewModel character)
        {
            CharacterId = character.CharacterId;
            CharacterName = character.CharacterName;
            CharacterBonus = character.CharacterBonus;
            CharacterType = character.CharacterType;
            CharacterMaximumHP = character.CharacterMaximumHP;
            CharacterCurrentHP = character.CharacterCurrentHP;
            database = new Models.CharactersDatabase();
        }

        public ICommand AddCharacterCommand => new Command(async () =>
        {
            Models.Character character = new Models.Character
            {
                CharacterId = CharacterId,
                CharacterName = CharacterName,
                CharacterBonus = CharacterBonus,
                CharacterType = CharacterType,
                CharacterCurrentHP = CharacterCurrentHP,
                CharacterMaximumHP = CharacterMaximumHP
            };
            await database.SaveCharacterAsync(character);
            await App.InitiativeViewModel.RefreshCharacters();
            //await AppShell.Current.Navigation.PushAsync(App.InitiativeViewModel);
        });
    }
}

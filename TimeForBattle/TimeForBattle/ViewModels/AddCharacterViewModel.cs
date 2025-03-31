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
        private string _characterDescription;
        private string _characterType;

        public int CharacterId {
            get { return _characterId; }
            set { SetProperty(ref _characterId, value); }
        }
        public string CharacterName {
            get { return _characterName; }
            set { SetProperty(ref _characterName, value); }
        }
        public string CharacterDescription {
            get { return _characterDescription; }
            set { SetProperty(ref _characterDescription, value); }
        }
        public string CharacterType
        {
            get { return _characterType; }
            set { SetProperty(ref _characterType, value); }
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
            CharacterDescription = character.CharacterDescription;
            CharacterType = character.CharacterType;
            database = new Models.CharactersDatabase();
        }

        public ICommand AddCharacterCommand => new Command(async () =>
        {
            Models.Character character = new Models.Character
            {
                CharacterId = CharacterId,
                CharacterName = CharacterName,
                CharacterDescription = CharacterDescription,
                CharacterType = CharacterType
            };
            await database.SaveCharacterAsync(character);
            await App.InitiativeViewModel.RefreshCharacters();
            //await AppShell.Current.Navigation.PushAsync(App.InitiativeViewModel);
        });
    }
}

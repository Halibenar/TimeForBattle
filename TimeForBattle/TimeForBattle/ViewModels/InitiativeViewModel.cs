using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TimeForBattle.ViewModels
{
    public class InitiativeViewModel: ObservableObject
    {
        private CharacterViewModel? _selectedCharacter;
        private Models.CharactersDatabase database;

        public CharacterViewModel? SelectedCharacter
        {
            get => _selectedCharacter;
            set => SetProperty(ref _selectedCharacter, value);
        }

        public ICommand DeleteCharacterCommand { get; private set; }

        public ObservableCollection<CharacterViewModel> Characters { get; set; }

        public InitiativeViewModel()
        {
            database = new Models.CharactersDatabase();
            Characters = [];
            DeleteCharacterCommand = new Command<CharacterViewModel>(DeleteCharacter);
        }

        public async Task RefreshCharacters()
        {
            IEnumerable<Models.Character> characterData = await database.GetCharactersAsync();

            foreach (Models.Character character in characterData)
                Characters.Add(new CharacterViewModel(character));
        }

        private void DeleteCharacter(CharacterViewModel character) =>
            Characters.Remove(character);
    }
}

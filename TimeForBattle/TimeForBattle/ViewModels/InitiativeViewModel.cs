using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using TimeForBattle.Views;
using System.Diagnostics;

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
        public ICommand UpdateCharacterCommand { get; private set; }

        public ObservableCollection<CharacterViewModel> Characters { get; set; }

        public InitiativeViewModel()
        {
            database = new Models.CharactersDatabase();
            Characters = [];
            DeleteCharacterCommand = new Command<CharacterViewModel>(DeleteCharacter);
            UpdateCharacterCommand = new Command<CharacterViewModel>(UpdateCharacter);
        }

        public async Task RefreshCharacters()
        {
            IEnumerable<Models.Character> characterData = await database.GetAllCharactersAsync();

            Characters.Clear();
            foreach (Models.Character character in characterData)
                Characters.Add(new CharacterViewModel(character));
        }

        private async void DeleteCharacter(CharacterViewModel character)
        {
            if (await database.DeleteCharacterAsync(await database.GetCharacterAsync(character.CharacterId)) > 0)
            {
                Characters.Remove(character);
            }
        }

        private async void UpdateCharacter(CharacterViewModel character)
        {
            await AppShell.Current.Navigation.PushAsync(new Views.AddCharacterPage(character));
        }

        public void RollInitiative()
        {
            Random rng = new Random();

            foreach (var character in Characters)
            {
                int initiative = rng.Next(1, 21) + character.CharacterBonus;
                character.CharacterInitiative = initiative;
                character.CharacterInitiativeString = initiative.ToString();
                Trace.WriteLine(character.CharacterName + ", " + character.CharacterInitiativeString);
            }

            var sortedCharacters = Characters.OrderByDescending(x => x.CharacterInitiative).ThenByDescending(x => x.CharacterBonus).ToList();

            Characters.Clear();
            foreach (var character in sortedCharacters)
            {
                Characters.Add(character);
            }
        }
    }
}

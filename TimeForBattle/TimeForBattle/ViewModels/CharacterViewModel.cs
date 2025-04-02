using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TimeForBattle.ViewModels
{
    public class CharacterViewModel: ObservableObject
    {
        private int _characterId;
        private string _characterName;
        private int _characterBonus;
        private string _characterType;
        private int _characterMaximumHP;
        private int _characterCurrentHP;

        private int _characterInitiative;
        private string _characterInitiativeString;

        public int CharacterId
        {
            get => _characterId;
            set => SetProperty(ref _characterId, value);
        }

        public string CharacterName
        {
            get => _characterName;
            set => SetProperty(ref _characterName, value);
        }

        public int CharacterBonus
        {
            get => _characterBonus;
            set => SetProperty(ref _characterBonus, value);
        }

        public string CharacterType
        {
            get => _characterType;
            set => SetProperty(ref _characterType, value);
        }

        public int CharacterInitiative
        {
            get => _characterInitiative;
            set => SetProperty(ref _characterInitiative, value);
        }

        public String CharacterInitiativeString
        {
            get => _characterInitiativeString;
            set => SetProperty(ref _characterInitiativeString, value);
        }

        public int CharacterMaximumHP
        {
            get => _characterMaximumHP;
            set => SetProperty(ref _characterMaximumHP, value);
        }

        public int CharacterCurrentHP 
        {
            get => _characterCurrentHP;
            set => SetProperty(ref _characterCurrentHP, value);
        }

        public CharacterViewModel(Models.Character character)
        {
            _characterId = character.CharacterId;
            _characterName = character.CharacterName;
            _characterBonus = character.CharacterBonus;
            _characterType = character.CharacterType;
            _characterMaximumHP = character.CharacterMaximumHP;
            _characterCurrentHP = character.CharacterCurrentHP;
            _characterInitiativeString = "";
        }
    }
}

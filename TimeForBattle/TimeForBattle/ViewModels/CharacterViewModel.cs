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

        public CharacterViewModel(Models.Character character)
        {
            _characterId = character.CharacterId;
            _characterName = character.CharacterName;
            _characterBonus = character.CharacterBonus;
            _characterType = character.CharacterType;
        }
    }
}

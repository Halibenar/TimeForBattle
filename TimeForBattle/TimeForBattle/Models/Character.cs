using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TimeForBattle.Models
{
    public class Character
    {
        private int _characterId;
        private string _characterName;
        private int _characterBonus;
        private string _characterType;
        private int _characterMaximumHP;
        private int _characterCurrentHP;

        [PrimaryKey, AutoIncrement]  public int CharacterId { get => _characterId; set => _characterId = value; }
        public string CharacterName { get => _characterName; set => _characterName = value; }
        public int CharacterBonus { get => _characterBonus; set => _characterBonus = value; }
        public string CharacterType { get => _characterType; set => _characterType = value; }
        public int CharacterMaximumHP { get => _characterMaximumHP; set => _characterMaximumHP = value; }
        public int CharacterCurrentHP { get => _characterCurrentHP; set => _characterCurrentHP = value; }

        public Character()
        {

        }
    }
}

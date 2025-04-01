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

        [PrimaryKey, AutoIncrement]  public int CharacterId { get => _characterId; set => _characterId = value; }
        public string CharacterName { get => _characterName; set => _characterName = value; }
        public int CharacterBonus { get => _characterBonus; set => _characterBonus = value; }
        public string CharacterType { get => _characterType; set => _characterType = value; }

        public Character()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TimeForBattle.Models
{
    internal class CharactersDatabase
    {
        SQLiteAsyncConnection database;

        public async Task Init()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await database.CreateTableAsync<Character>();
        }

        public async Task<IEnumerable<Character>> GetAllCharactersAsync()
        {
            await Init();
            return await database.Table<Character>().ToListAsync();
        }

        public async Task<Character> GetCharacterAsync(int id)
        {
            await Init();
            return await database.Table<Character>().Where(i => i.CharacterId == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveCharacterAsync(Character character)
        {
            await Init();
            if (character.CharacterId != 0)
                return await database.UpdateAsync(character);
            else
                return await database.InsertAsync(character);
        } 

        public async Task<int> DeleteCharacterAsync(Character character)
        {
            await Init();
            return await database.DeleteAsync(character);
        }
    }
}

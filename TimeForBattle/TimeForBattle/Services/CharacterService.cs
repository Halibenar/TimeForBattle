using SQLite;

namespace TimeForBattle.Services;

public class CharacterService
{
    SQLiteAsyncConnection database;

    async Task Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await database.CreateTableAsync<Character>();
    }

    public void TestCharacters()
    {
        //Character characterA = new Character();
        //characterA.Id = 0;
        //characterA.Name = "Martijn";
        //characterA.Initiative = 25;
        //characterA.Bonus = 9;
        //characterA.Type = "O";
        //characterA.MaximumHP = 99;
        //characterA.CurrentHP = 99;

        //SaveCharacterAsync(characterA);
    }

    public async Task<List<Character>> GetCharactersAsync()
    {
        await Init();
        TestCharacters();
        return await database.Table<Character>().ToListAsync();
    }

    public async Task<Character> GetCharacterAsync(int id)
    {
        await Init();
        return await database.Table<Character>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveCharacterAsync(Character character)
    {
        await Init();
        if (character.Id != 0)
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

using SQLite;

namespace TimeForBattle.Services;

public partial class CreatureService<T> where T : DatabaseObject, new()
{
    SQLiteAsyncConnection database;

    async Task Init()
    {
        if (database is null)
            database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await database.CreateTableAsync<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        await Init();
        return await database.Table<T>().ToListAsync();
    }

    public async Task<List<T>> GetAllByCategoryAsync(int category)
    {
        await Init();
        return await database.Table<T>().Where(i => i.Category == category).ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        await Init();
        return await database.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveAsync(T t)
    {
        await Init();

        if (t.Id != 0)
            return await database.UpdateAsync(t);
        else
            return await database.InsertAsync(t);
        
    } 

    public async Task<int> DeleteAsync(T t)
    {
        await Init();
        return await database.DeleteAsync(t);
    }
}

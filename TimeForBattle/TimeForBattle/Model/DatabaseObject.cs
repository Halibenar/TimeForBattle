using SQLite;

namespace TimeForBattle.Model;

public class DatabaseObject
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
}

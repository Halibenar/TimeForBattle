using SQLite;

namespace TimeForBattle.Model;

public partial class DatabaseObject : ObservableObject
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
}

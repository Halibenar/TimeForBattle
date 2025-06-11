using SQLite;

namespace TimeForBattle.Model;

public class Character
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public string Name { get; set; }
    public int Initiative { get; set; }
    public int Bonus { get; set; }
    public string Type { get; set; }
    public int MaximumHP { get; set; }
    public int CurrentHP { get; set; }

}
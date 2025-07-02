namespace TimeForBattle.Model;

public partial class Combat : DatabaseObject
{
    [ObservableProperty] public string name;
    [ObservableProperty] public int turnCount;
    public int currentTurnCreatureID;

    public Combat()
    {
        turnCount = 0;
    }
}

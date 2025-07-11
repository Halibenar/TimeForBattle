namespace TimeForBattle.Model;

public partial class Combat : DatabaseObject
{
    [ObservableProperty] public string name;
    [ObservableProperty] public int roundCount;
    [ObservableProperty] public bool isStarted;
    public int currentTurnCreatureID;
    
    public Combat()
    {
        roundCount = 1;
        isStarted = false;
    }
}

namespace TimeForBattle.Model;

public partial class Creature : DatabaseObject
{
    [ObservableProperty] public bool isPlayer;

    [ObservableProperty] public string name;
    [ObservableProperty] public string size;
    [ObservableProperty] public string type;
    [ObservableProperty] public string alignment;

    [ObservableProperty] public int armorClass;
    [ObservableProperty] public int initiativeBonus;
    [ObservableProperty] public int maximumHitPoints;
    [ObservableProperty] public string speed;
    [ObservableProperty] public string challengeRating;

    [ObservableProperty] public int strScore;
    [ObservableProperty] public int dexScore;
    [ObservableProperty] public int conScore;
    [ObservableProperty] public int intScore;
    [ObservableProperty] public int wisScore;
    [ObservableProperty] public int chaScore;

    [ObservableProperty] public string strSave;
    [ObservableProperty] public string dexSave;
    [ObservableProperty] public string conSave;
    [ObservableProperty] public string intSave;
    [ObservableProperty] public string wisSave;
    [ObservableProperty] public string chaSave;

    [ObservableProperty] public string skills;
    [ObservableProperty] public string resistances;
    [ObservableProperty] public string vulnerabilities;
    [ObservableProperty] public string immunities;
    [ObservableProperty] public string senses;
    [ObservableProperty] public string languages;
    [ObservableProperty] public string gear;

    [ObservableProperty] public string traits;

    [ObservableProperty] public string actions;
    [ObservableProperty] public string bonusActions;
    [ObservableProperty] public string reactions;
    [ObservableProperty] public string legendaryActions;
}
namespace TimeForBattle.Model;

public class Creature : DatabaseObject
{
    public string Name { get; set; }
    public String Size { get; set; }
    public string Type { get; set; }
    public String Alignment { get; set; }

    public int ArmorClass { get; set; }
    public int InitiativeBonus { get; set; }
    public int MaximumHitPoints { get; set; }
    public int Speed { get; set; }
    public float ChallengeRating { get; set; }

    public int StrScore { get; set; }
    public int DexScore { get; set; }
    public int ConScore { get; set; }
    public int IntScore { get; set; }
    public int WisScore { get; set; }
    public int ChaScore { get; set; }

    public String SavingThrows { get; set; }
    public String Skills { get; set; }
    public String Resistances { get; set; }
    public String Vulnerabilities { get; set; }
    public String Immunities { get; set; }
    public String Senses { get; set; }
    public String Languages { get; set; }
    public String Gear { get; set; }

    public String Traits { get; set; }

    public String Actions { get; set; }
    public String BonusActions { get; set; }
    public String Reactions { get; set; }
    public String LegendaryActions { get; set; }
}
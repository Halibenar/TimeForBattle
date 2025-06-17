namespace TimeForBattle.Model;

public partial class Creature : DatabaseObject
{
    public string Name { get; set; }
    public string Size { get; set; }
    public string Type { get; set; }
    public string Alignment { get; set; }

    [ObservableProperty] public int armorClass;
    public int InitiativeBonus { get; set; }
    public int MaximumHitPoints { get; set; }
    public string Speed { get; set; }
    public string ChallengeRating { get; set; }

    public int StrScore { get; set; }
    public int DexScore { get; set; }
    public int ConScore { get; set; }
    public int IntScore { get; set; }
    public int WisScore { get; set; }
    public int ChaScore { get; set; }

    public string SavingThrows { get; set; }
    public string Skills { get; set; }
    public string Resistances { get; set; }
    public string Vulnerabilities { get; set; }
    public string Immunities { get; set; }
    public string Senses { get; set; }
    public string Languages { get; set; }
    public string Gear { get; set; }

    public string Traits { get; set; }

    public string Actions { get; set; }
    public string BonusActions { get; set; }
    public string Reactions { get; set; }
    public string LegendaryActions { get; set; }
}
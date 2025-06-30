
namespace TimeForBattle.Model;

public partial class InitiativeCreature : Creature
{
    public int CreatureID { get; set; }
    [ObservableProperty] public int? gridID;
    [ObservableProperty] public int currentHitPoints;
    [ObservableProperty] public int? initiative;

    public InitiativeCreature() { }

    public InitiativeCreature(Creature creature)
    {
        this.CreatureID = creature.Id;
        this.Initiative = null;
        this.GridID = null;
        this.CurrentHitPoints = creature.MaximumHitPoints;

        this.Name = creature.Name;
        this.IsPlayer = creature.IsPlayer;
        this.Size = creature.Size;
        this.Type = creature.Type;
        this.Alignment = creature.Alignment;

        this.ArmorClass = creature.ArmorClass;
        this.InitiativeBonus = creature.InitiativeBonus;
        this.MaximumHitPoints = creature.MaximumHitPoints;
        this.Speed = creature.Speed;
        this.ChallengeRating = creature.ChallengeRating;

        this.StrScore = creature.StrScore;
        this.DexScore = creature.DexScore;
        this.ConScore = creature.ConScore;
        this.IntScore = creature.IntScore;
        this.WisScore = creature.WisScore;
        this.ChaScore = creature.ChaScore;

        this.StrSave = creature.StrSave;
        this.DexSave = creature.DexSave;
        this.ConSave = creature.ConSave;
        this.IntSave = creature.IntSave;
        this.WisSave = creature.WisSave;
        this.ChaSave = creature.ChaSave;

        this.Skills = creature.Skills;
        this.Resistances = creature.Resistances;
        this.Vulnerabilities = creature.Vulnerabilities;
        this.Immunities = creature.Immunities;
        this.Senses = creature.Senses;
        this.Languages = creature.Languages;
        this.Gear = creature.Gear;

        this.Traits = creature.Traits;

        this.Actions = creature.Actions;
        this.BonusActions = creature.BonusActions;
        this.Reactions = creature.Reactions;
        this.LegendaryActions = creature.LegendaryActions;
    }
}



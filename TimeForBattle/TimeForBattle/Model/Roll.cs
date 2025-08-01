namespace TimeForBattle.Model;

public partial class Roll : ObservableObject
{
    [ObservableProperty] string creatureName;
    [ObservableProperty] string rollName;
    [ObservableProperty] int rollValue1;
    [ObservableProperty] int rollValue2;
    [ObservableProperty] int modifier;
    [ObservableProperty] string modifierString;

    public Roll(string creatureName, string rollName, int rollValue1, int rollValue2, int modifier)
    {
        CreatureName = creatureName;
        RollName = rollName;
        RollValue1 = rollValue1;
        RollValue2 = rollValue2;
        Modifier = modifier;
        if (Modifier < 0)
            ModifierString = Modifier.ToString();
        else
            ModifierString = "+" + Modifier.ToString();
    }
}
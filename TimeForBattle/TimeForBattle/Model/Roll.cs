namespace TimeForBattle.Model;

public partial class Roll(string creatureName, string rollName, int rollValue1, int rollValue2, int modifier) : ObservableObject
{
    [ObservableProperty] string creatureName = creatureName;
    [ObservableProperty] string rollName = rollName;
    [ObservableProperty] int rollValue1 = rollValue1;
    [ObservableProperty] int rollValue2 = rollValue2;
    [ObservableProperty] int modifier = modifier;
}
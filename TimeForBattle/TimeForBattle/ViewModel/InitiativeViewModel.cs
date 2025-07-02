using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

[QueryProperty("Combat", "Combat")]
public partial class InitiativeViewModel : BaseViewModel
{
    public CreatureService<InitiativeCreature> InitiativeService;
    [ObservableProperty] public ObservableCollection<InitiativeCreature> initiative = new();
    [ObservableProperty] Combat combat;

    public InitiativeViewModel(CreatureService<InitiativeCreature> initiativeService)
    {
        this.InitiativeService = initiativeService;
        Initiative = [];
    }

    [RelayCommand]
    public async Task RefreshInitiative()
    {
        List<InitiativeCreature> initiativeCreatureData = await InitiativeService.GetAllAsync();
        Initiative.Clear();

        foreach (InitiativeCreature initiativeCreature in initiativeCreatureData)
        {
            Initiative.Add(initiativeCreature);
        }
        SortInitiative();
    }

    [RelayCommand]
    void RollInitiative()
    {
        if (Initiative is null || Initiative.Count == 0)
            return;

        Random rng = new();

        foreach (InitiativeCreature creature in Initiative)
        {
            if (!creature.IsPlayer)
            {
                int initiative = rng.Next(1, 21) + creature.InitiativeBonus;
                creature.Initiative = initiative;
                Task.Run(() => InitiativeService.SaveAsync(creature));
            }
        }

        SortInitiative();

        InitiativeCreature? currentCreature = Initiative.FirstOrDefault(x => x.IsTurn == true, null);

        if (currentCreature is not null)
        {
            currentCreature.IsTurn = false;
            Task.Run(() => InitiativeService.SaveAsync(currentCreature));
        }

        Initiative[0].IsTurn = true;
        Task.Run(() => InitiativeService.SaveAsync(Initiative[0]));
    }

    [RelayCommand]
    public void SortInitiative()
    {
        if (Initiative is null || Initiative.Count == 0)
            return;

        var sortedCreatures = Initiative.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.InitiativeBonus).ToList();

        Initiative.Clear();
        foreach (var creature in sortedCreatures)
        {
            Initiative.Add(creature);
        }
    }

    [RelayCommand]
    public void NextCreature()
    {
        if (Initiative is null || Initiative.Count == 0)
            return;

        InitiativeCreature? currentCreature = Initiative.FirstOrDefault(x => x.IsTurn == true, null);
        InitiativeCreature? nextCreature = null;

        if (currentCreature is not null)
        {
            if (Initiative.IndexOf(currentCreature) + 1 < Initiative.Count)
                nextCreature = Initiative[Initiative.IndexOf(currentCreature) + 1];
            else
                nextCreature = Initiative[0];

            currentCreature.IsTurn = false;
            Task.Run(() => InitiativeService.SaveAsync(currentCreature));
        }
        else
            nextCreature = Initiative[0];

        if (nextCreature is not null)
        {
            nextCreature.IsTurn = true;
            Task.Run(() => InitiativeService.SaveAsync(nextCreature));
        }

    }

    [RelayCommand]
    public void PreviousCreature()
    {
        if (Initiative is null || Initiative.Count == 0)
            return;

        InitiativeCreature? currentCreature = Initiative.FirstOrDefault(x => x.IsTurn == true, null);
        InitiativeCreature? previousCreature = null;

        if (currentCreature is not null)
        {
            if (Initiative.IndexOf(currentCreature) - 1 >= 0)
                previousCreature = Initiative[Initiative.IndexOf(currentCreature) - 1];
            else
                previousCreature = Initiative[^1];

            currentCreature.IsTurn = false;
            Task.Run(() => InitiativeService.SaveAsync(currentCreature));
        }
        else
            previousCreature = Initiative[0];

        if (previousCreature is not null)
        {
            previousCreature.IsTurn = true;
            Task.Run(() => InitiativeService.SaveAsync(previousCreature));
        }
    }
}

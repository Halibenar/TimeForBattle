using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

[QueryProperty("Creature", "Creature")]
public partial class AddCreatureViewModel : BaseViewModel
{
    public CreatureService<Creature> creatureService;

    public AddCreatureViewModel(CreatureService<Creature> characterService)
    {
        this.creatureService = characterService;
    }

    [ObservableProperty] Creature creature;

    [RelayCommand]
    public async Task SaveCreatureAsync()
    {
        if (Creature is null)
            return;

        await creatureService.SaveAsync(Creature);
    }
}

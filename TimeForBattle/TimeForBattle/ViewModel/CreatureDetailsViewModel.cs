using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

[QueryProperty("Creature", "Creature")]
public partial class CreatureDetailsViewModel: BaseViewModel
{
    public CreatureService<Creature> creatureService;

    public CreatureDetailsViewModel(CreatureService<Creature> characterService)
    {
        this.creatureService = characterService;
        //GetCreature(creature.Id);
    }

    [ObservableProperty] Creature creature;

    [RelayCommand]
    public async Task GoToEditAsync()
    {
        if (Creature is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(AddCreaturePage)}", true,
            new Dictionary<string, object>
            {
                {"Creature", Creature}
            });
    }

    [RelayCommand]
    public async Task Refresh()
    {
        //this.creature = await this.creatureService.GetByIdAsync(this.creature.Id);
        Trace.WriteLine(Creature.ArmorClass);
    }
}

using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle.ViewModel;

[QueryProperty("Creature", "Creature")]
public partial class AddCreatureViewModel : BaseViewModel
{
    public CreatureService<Creature> creatureService;
    public DialogService dialogService;

    public AddCreatureViewModel(CreatureService<Creature> characterService, DialogService dialogService)
    {
        this.creatureService = characterService;
        this.dialogService = dialogService;
    }

    [ObservableProperty] Creature creature;

    [RelayCommand]
    public async Task SaveCreatureAsync()
    {
        if (Creature is null)
            return;

        await creatureService.SaveAsync(Creature);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task DeleteCreatureAsync()
    {
        if (Creature is null)
            return;

        bool answer = await dialogService.ShowConfirmationAsync((ContentPage)AppShell.Current.CurrentPage, "Delete?", "Are you sure you want to delete this creature?", "Yes", "No");
        if (answer)
        {
            if (await creatureService.GetByIdAsync(Creature.Id) is not null) {
                await creatureService.DeleteAsync(await creatureService.GetByIdAsync(Creature.Id));
            }
            await Shell.Current.GoToAsync("../..");
        }
    }
}

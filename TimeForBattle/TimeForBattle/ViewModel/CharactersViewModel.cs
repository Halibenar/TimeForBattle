using System.Windows.Input;
using TimeForBattle.Services;

namespace TimeForBattle.ViewModel;

public partial class CharactersViewModel: BaseViewModel
{
    CharacterService characterService;
    public ObservableCollection<Character> Characters { get; } = new ();

    public CharactersViewModel(CharacterService characterService)
    {
        Title = "Initiative";
        this.characterService = characterService;
        Characters = [];
        RefreshCharacters();
    }

    [ObservableProperty] bool isRefreshing;

    [RelayCommand]
    public async Task RefreshCharacters()
    {
        List<Character> characterData = await characterService.GetCharactersAsync();

        Characters.Clear();
        foreach (Character character in characterData)
        {
            Characters.Add(character);
            Trace.WriteLine(character.Id);
        }
    }

    [RelayCommand]
    async Task DeleteCharacter(Character character)
    {
        if (await characterService.DeleteCharacterAsync(await characterService.GetCharacterAsync(character.Id)) > 0)
        {
            Characters.Remove(character);
        }
    }

    [RelayCommand]
    async Task UpdateCharacter(Character character)
    {
        await AppShell.Current.Navigation.PushAsync(new View.AddCharacterPage());
    }

    [RelayCommand]
    void RollInitiative()
    {
        Random rng = new Random();

        Parallel.ForEach(Characters, character =>
        {
            //if (character.Type == "NPC")
            
                int initiative = rng.Next(1, 21) + character.Bonus;
                character.Initiative = initiative;
                characterService.SaveCharacterAsync(character);
            
        });

        SortInitiative();
    }

    [RelayCommand]
    void SortInitiative()
    {
        var sortedCharacters = Characters.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.Bonus).ToList();

        Characters.Clear();
        foreach (var character in sortedCharacters)
        {
            Characters.Add(character);
        }
    }
}

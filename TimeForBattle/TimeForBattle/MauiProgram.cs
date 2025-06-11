using Microsoft.Extensions.Logging;
using TimeForBattle.Services;
using TimeForBattle.View;

namespace TimeForBattle;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<CharactersPage>();
        builder.Services.AddTransient<CharacterPage>();

        builder.Services.AddSingleton<CharactersViewModel>();
        builder.Services.AddTransient<CharacterDetailsViewModel>();

        builder.Services.AddSingleton<CharacterService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}

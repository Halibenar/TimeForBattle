using Microsoft.Extensions.Logging;
using TimeForBattle.Services;
using TimeForBattle.View;
using CommunityToolkit.Maui;

namespace TimeForBattle;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<MainMenuPage>();
        builder.Services.AddSingleton<CreatureListPage>();
        builder.Services.AddTransient<CreatureDetailsPage>();
		builder.Services.AddTransient<AddCreaturePage>();
		builder.Services.AddSingleton<InitiativePage>();

        builder.Services.AddSingleton<MainMenuViewModel>();
        builder.Services.AddSingleton<CreatureListViewModel>();
        builder.Services.AddTransient<CreatureDetailsViewModel>();
        builder.Services.AddTransient<AddCreatureViewModel>();
        builder.Services.AddSingleton<InitiativeViewModel>();

        builder.Services.AddSingleton<CreatureService<Combat>>();
        builder.Services.AddSingleton<CreatureService<Creature>>();
		builder.Services.AddSingleton<InitiativeService<InitiativeCreature>>();
		builder.Services.AddSingleton<DialogService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}

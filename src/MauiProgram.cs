using Hangry.ViewModel;
using Microsoft.Extensions.Logging;

namespace Hangry;

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
                fonts.AddFont("Cursive-standard-Bold.ttf", "CursivestandardBold");
                fonts.AddFont("Cursive-standard.ttf", "Cursivestandard");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<PantryPage>();
        builder.Services.AddSingleton<PantryViewModel>();

        builder.Services.AddSingleton<RecipePage>();
        builder.Services.AddSingleton<RecipeViewModel>();

        builder.Services.AddSingleton<FoodData>();

        return builder.Build();
	}
}

using Microsoft.Extensions.Logging;
using MVP.PrismMaui.ViewModels;
using MVP.PrismMaui.Views;

namespace MVP.PrismMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UsePrism(prism =>
            {
                prism.RegisterTypes(types =>
                {
                    types.RegisterForNavigation<HeroesView, HeroesViewModel>();
                })
                .ConfigureServices(services =>
                {
                    //services.AddSingleton<>();
                })
                .OnAppStart(async (start) =>
                {
                    await start.NavigateAsync("HeroesView");
                });
            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

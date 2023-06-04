using Microsoft.Extensions.Logging;
using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Services.Heroes;
using MVP.PrismMaui.Services;
using MVP.PrismMaui.Services.Abstractions;
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
                    types.RegisterForNavigation<HeroDetailsView, HeroDetailsViewModel>();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ICheckConnectivityService, CheckConnectivityService>();
                    services.AddSingleton<IHeroesService, HeroesService>();
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

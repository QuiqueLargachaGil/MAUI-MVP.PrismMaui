using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Services.Locations;
using MVP.PrismMaui.ViewModels;
using MVP.PrismMaui.Views;
using Prism;
using Prism.Ioc;

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
					types.RegisterForNavigation<MainView, MainViewModel>();
                    types.RegisterForNavigation<ResultDetailsView, ResultDetailsViewModel>();
                })
				.ConfigureServices(services =>
				{
					services.AddSingleton<ILocationServices, LocationServices>();
				})
				.OnAppStart(async (start) =>
				{
					await start.NavigateAsync("MainView");
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

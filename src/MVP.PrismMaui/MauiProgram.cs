using Microsoft.Extensions.Logging;
using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Services.Heroes;
using MVP.PrismMaui.Services;
using MVP.PrismMaui.Services.Abstractions;
using MVP.PrismMaui.ViewModels;
using MVP.PrismMaui.Views;
using Prism;
using Prism.Navigation;

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
                    types.RegisterForNavigation<FavouritesView, FavouritesViewModel>();
                    types.RegisterForNavigation<AboutView, AboutViewModel>();

                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ICheckConnectivityService, CheckConnectivityService>();
                    services.AddSingleton<IVersionService, VersionService>();
                    services.AddSingleton<IHeroesService, HeroesService>();
                })
                // SIN BARRA DE NAVEGACIÓN, PANTALLAS SENCILLAS SIN ELEMENTOS
                //.OnAppStart(async (start) =>
                //{
                //    await start.NavigateAsync("HeroesView");
                //});
                // CON BARRA DE NAVEGACIÓN
                //.OnAppStart(navigation =>
                //{
                //    navigation.CreateBuilder().AddNavigationPage().AddSegment("HeroesView").Navigate();
                //});
                // CON PESTAÑAS EN LA PARTE DE ARRIBA. NO SE PUEDEN PONER ABAJO?? EN LUGAR DE TÍTULO SE PUEDE PONER UNA IMAGEN?? NO SE PUEDE PONER NAVIGATIONPAGE A LAS PAGINAS A LAS QUE SE NAVEGA??
                .OnAppStart(onAppStarted: navigation =>
                {
                    navigation.CreateBuilder().AddTabbedSegment(configuration: page =>
                    {
                        page.CreateTab("HeroesView")
                            .CreateTab("FavouritesView")
                            .CreateTab("AboutView");
                        //.SelectedTab("AboutView");
                    }).Navigate();
                });

                // COMENTARIO DICIENDO DE DÓNDE SALE ESTE CÓDIGO
                //.OnAppStart(nav => nav.CreateBuilder()
                //    .AddTabbedSegment(page =>
                //        page.CreateTab("AboutView")
                //            .CreateTab(t =>
                //                t.AddNavigationPage()
                //                 .AddSegment("HeroesView", s => s.AddParameter("message", "Hello Tab - ViewA"))
                //                 .AddSegment("ViewB", s => s.AddParameter("message", "Hello Tab - ViewB")))
                //            .CreateTab("HeroDetailsView", s => s.AddParameter("message", "Hello Tab - ViewC"))
                //            .SelectedTab("NavigationPage|ViewB"))
                //    .AddParameter("message_global", "This is a Global Message")
                //    .Navigate());
                //.OnAppStart("HeroesView/ViewB/AboutView");
                //.OnAppStart(navigationService => navigationService.CreateBuilder()
                //    .AddSegment<RootPageViewModel>()
                //    .NavigateAsync());
                //.NavigateAsync(HandleNavigationError))
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

    // COMENTARIO DICIENDO DE DÓNDE SALE ESTE CÓDIGO
    //private static void HandleNavigationError(Exception ex)
    //{
    //    Console.WriteLine(ex);
    //    System.Diagnostics.Debugger.Break();
    //}
}

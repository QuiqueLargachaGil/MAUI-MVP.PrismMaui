using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Services.Heroes;
using MVP.PrismMaui.Services;
using MVP.PrismMaui.Services.Abstractions;
using MVP.PrismMaui.ViewModels;
using MVP.PrismMaui.Views;

namespace MVP.PrismMaui
{
	public static class PrismStartup
    {
        public static void Configure(PrismAppBuilder app)
        {
            app.RegisterTypes(RegisterTypes)
			   .ConfigureServices(ConfigureServices)
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
		}

		private static void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<HeroesView, HeroesViewModel>();
			containerRegistry.RegisterForNavigation<HeroDetailsView, HeroDetailsViewModel>();
			containerRegistry.RegisterForNavigation<FavouritesView, FavouritesViewModel>();
			containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<ICheckConnectivityService, CheckConnectivityService>();
			services.AddSingleton<IVersionService, VersionService>();

			services.AddSingleton<IHeroesService, HeroesService>();
		}

		private static async Task AddAppBasicNavigation<TView>(INavigationService start)
		{
			await start.NavigateAsync(typeof(TView).Name);
		}

		private static void AddAppNavigationBar<TView>(INavigationService navigation)
		{
			navigation.CreateBuilder().AddNavigationPage().AddSegment(typeof(TView).Name).Navigate();
		}

		// COMENTARIO DICIENDO DE DÓNDE SALE ESTE CÓDIGO
		//private static void HandleNavigationError(Exception ex)
		//{
		//    Console.WriteLine(ex);
		//    System.Diagnostics.Debugger.Break();
		//}
	}
}

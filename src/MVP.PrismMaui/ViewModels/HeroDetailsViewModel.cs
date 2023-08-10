using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Mappers;
using MVP.PrismMaui.Infrastructure.Services.Heroes.Models;
using MVP.PrismMaui.Models.Heroes;
using MVP.PrismMaui.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVP.PrismMaui.ViewModels
{
	public class HeroDetailsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        private readonly IHeroesService _heroesService;

        private Hero _hero;
        private ObservableCollection<ComicCover> _comics;

        public HeroDetailsViewModel(INavigationService navigationService, IHeroesService heroesService, IPageDialogService dialogService, IDialogService dialogs) : base(dialogService, dialogs)
        {
            _navigationService = navigationService;

            _heroesService = heroesService;

            BackCommand = new Command(async () => await Back());
        }

		public override async Task OnNavigatedImplementation(INavigationParameters parameters)
		{
			await base.OnNavigatedImplementation(parameters);

			var hero = parameters.GetValue<Hero>("SelectedHero");
			await LoadData(hero);
		}

        public ICommand BackCommand { get; }

        public Hero Hero
        {
            get => _hero;
            set => SetProperty(ref _hero, value);
        }

        public ObservableCollection<ComicCover> Comics
        {
            get => _comics;
            set => SetProperty(ref _comics, value);
        }

        private async Task LoadData(Hero hero)
        {
            try
            {
                Title = hero.Name;
                Hero = hero;

                var request = new ComicsRequest(GetBaseUrl(hero.Comics.CollectionURI), GetPath(hero.Comics.CollectionURI));
                var response = await _heroesService.GetComicsByHero(request);
                var comics = BackendToModelMapper.GetComicsCover(response);

                Comics = new ObservableCollection<ComicCover>(comics);
            }
            catch (Exception exception)
            {
                await HandleExceptions(exception);
            }
        }

        private string GetBaseUrl(string uri)
        {
            var pattern = "com";
            var lastBaseUrlIndex = uri.IndexOf(pattern);
            return uri[..(lastBaseUrlIndex + pattern.Length)];
        }

        private string GetPath(string uri)
        {
            var pattern = "com";
            var lastBaseUrlIndex = uri.IndexOf(pattern);
            return uri.Substring(lastBaseUrlIndex + pattern.Length); ;
        }

        private async Task Back()
        {
            await _navigationService.GoBackAsync();
        }
	}    
}

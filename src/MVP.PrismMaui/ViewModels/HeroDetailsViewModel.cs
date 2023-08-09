using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Mappers;
using MVP.PrismMaui.Infrastructure.Services.Heroes.Models;
using MVP.PrismMaui.Models.Heroes;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVP.PrismMaui.ViewModels
{
	public class HeroDetailsViewModel : BindableBase, INavigatedAware
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;

        private readonly IHeroesService _heroesService;

        private string _title;
        private Hero _hero;
        private ObservableCollection<ComicCover> _comics;

        public HeroDetailsViewModel(INavigationService navigationService, IPageDialogService dialogService, IHeroesService heroesService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

            _heroesService = heroesService;

            BackCommand = new Command(async () => await Back());
        }

		public void OnNavigatedFrom(INavigationParameters parameters)
		{
			
		}

		public async void OnNavigatedTo(INavigationParameters parameters)
		{
			var hero = parameters.GetValue<Hero>("SelectedHero");
			await LoadData(hero);
		}

        public ICommand BackCommand { get; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

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
                await _dialogService.DisplayAlertAsync("MarvelApp", exception.Message, "Ok");
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

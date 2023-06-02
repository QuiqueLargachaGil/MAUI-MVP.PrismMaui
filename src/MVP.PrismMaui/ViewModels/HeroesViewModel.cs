using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Mappers;
using MVP.PrismMaui.Infrastructure.Services.Heroes;
using MVP.PrismMaui.Models.Heroes;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVP.PrismMaui.ViewModels
{
    public class HeroesViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly IHeroesService _heroesService;

        private ObservableCollection<Hero> _heroes;
        private bool _isRefreshing;

        public HeroesViewModel(INavigationService navigationService, IHeroesService heroesService)
        {
            _navigationService = navigationService;
            _heroesService = heroesService;

            RefreshCommand = new Command(async () => await Refresh());
            NavigateToHeroDetailsCommand = new Command<Hero>(async (selectedHero) => await NavigateToHeroDetails(selectedHero));
            
            LoadData();
        }

        public ICommand RefreshCommand { get; }
        public ICommand NavigateToHeroDetailsCommand { get; }

        public ObservableCollection<Hero> Heroes
        {
            get => _heroes;
            set => SetProperty(ref _heroes, value);
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        private async Task LoadData()
        {
            try
            {
                var request = new HeroesRequest("https://gateway.marvel.com:443");
                var response = await _heroesService.GetHeroes(request);
                var heroes = BackendToModelMapper.GetHeroes(response);

                Heroes = new ObservableCollection<Hero>(heroes);
            }
            catch (Exception exception)
            {
                //HandleException(exception);
                await Application.Current.MainPage.DisplayAlert("MarvelApp", exception.Message, "Ok");
            }
        }

        private async Task Refresh()
        {
            IsRefreshing = true;
            await LoadData();
            IsRefreshing = false;
        }

        private async Task NavigateToHeroDetails(Hero selectedHero)
        {
            var parameters = new NavigationParameters
            {
                { "SelectedHero", selectedHero }
            };

            await _navigationService.NavigateAsync("HeroDetailsView", parameters);
        }
    }
}

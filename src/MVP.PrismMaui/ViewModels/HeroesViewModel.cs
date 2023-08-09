using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Mappers;
using MVP.PrismMaui.Infrastructure.Services.Heroes.Models;
using MVP.PrismMaui.Models.Heroes;
using MVP.PrismMaui.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVP.PrismMaui.ViewModels
{
	public class HeroesViewModel : BaseViewModel
	{
        private readonly INavigationService _navigationService;

        private readonly IHeroesService _heroesService;

        private ObservableCollection<Hero> _heroes;
        private IEnumerable<Hero> _heroesList;
        private bool _isRefreshing;

        public HeroesViewModel(INavigationService navigationService, IHeroesService heroesService, IPageDialogService dialogService, IDialogService dialogs) : base(dialogService, dialogs)
        {
            _navigationService = navigationService;

            _heroesService = heroesService;

            SearchHeroCommand = new Command<string>((textToSearch) => SearchHero(textToSearch));
            RefreshCommand = new Command(async () => await Refresh());
            NavigateToHeroDetailsCommand = new Command<Hero>(async (selectedHero) => await NavigateToHeroDetails(selectedHero));
        }

		public override async Task OnNavigatedImplementation(INavigationParameters parameters)
		{
            await base.OnNavigatedImplementation(parameters);
			await LoadData();
		}

		public ICommand SearchHeroCommand { get; }
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
                _heroesList = BackendToModelMapper.GetHeroes(response);

                Heroes = new ObservableCollection<Hero>(_heroesList);
            }
            catch (Exception exception)
            {
				await HandleExceptions(exception);                
            }
        }

        // TODO find better method to search and display the search results
        private void SearchHero(string textToSearch)
        {
            if (string.IsNullOrEmpty(textToSearch))
            {
                Heroes = new ObservableCollection<Hero>(_heroesList);
            }
            else
            {
                var filteredHeroes = _heroesList.Where(x => x.Name.ToLower().Contains(textToSearch.ToLower())).ToList();
                Heroes = new ObservableCollection<Hero>(filteredHeroes);
            }
        }

        private async Task Refresh()
        {
            IsBusy = true;
            await LoadData();
            IsBusy = false;
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

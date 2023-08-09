using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Mappers;
using MVP.PrismMaui.Infrastructure.Services.Heroes.Models;
using MVP.PrismMaui.Models.Heroes;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVP.PrismMaui.ViewModels
{
	public class HeroesViewModel : BindableBase, INavigatedAware
	{
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        private readonly IDialogService _dialog;

        private readonly IHeroesService _heroesService;

        private ObservableCollection<Hero> _heroes;
        private IEnumerable<Hero> _heroesList;
        private bool _isRefreshing;

        public HeroesViewModel(INavigationService navigationService, IPageDialogService dialogService, IDialogService dialog, IHeroesService heroesService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _dialog = dialog;

            _heroesService = heroesService;

            SearchHeroCommand = new Command<string>((textToSearch) => SearchHero(textToSearch));
            RefreshCommand = new Command(async () => await Refresh());
            NavigateToHeroDetailsCommand = new Command<Hero>(async (selectedHero) => await NavigateToHeroDetails(selectedHero));
        }

		public void OnNavigatedFrom(INavigationParameters parameters)
		{
			
		}

		public async void OnNavigatedTo(INavigationParameters parameters)
		{
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
				//HandleException(exception);
				await _dialogService.DisplayAlertAsync("MarvelApp", exception.Message, "Ok");
                
                // Tal y como se indica en la documentación de Prism, la interface IDialogService, aún no está disponible para MAUI
                //_dialog.ShowDialog("PRUEBA");
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

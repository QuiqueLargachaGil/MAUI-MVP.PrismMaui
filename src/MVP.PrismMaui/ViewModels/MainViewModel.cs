using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Mappers;
using MVP.PrismMaui.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVP.PrismMaui.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly ILocationServices _locationServices;
        private readonly INavigationService _navigationService;

        private ObservableCollection<Result> _results;

        public MainViewModel(INavigationService navigationService, ILocationServices locationServices)
        {
            _navigationService = navigationService;
            _locationServices = locationServices;

            NavigateToResultDetailsCommand = new Command<Result>((selectedResult) => NavigateToResultDetails(selectedResult));

            LoadData();
        }

        public ICommand NavigateToResultDetailsCommand { get; }

        public ObservableCollection<Result> Results
        {
            get => _results;
            set => SetProperty(ref _results, value);
        }

        private async Task LoadData()
        {
            var response = await _locationServices.GetLocations(40.7, -74);
            var results = BackendToModelMapper.GetResults(response.Results);

            Results = new ObservableCollection<Result>(results);
        }

        private async void NavigateToResultDetails(Result selectedResult)
        {
            var parameters = new NavigationParameters
            {
                { "SelectedResult", selectedResult }
            };

            await _navigationService.NavigateAsync("ResultDetailsView", parameters);
        }
    }
}

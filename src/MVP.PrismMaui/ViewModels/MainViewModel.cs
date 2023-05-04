using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Mappers;

namespace MVP.PrismMaui.ViewModels
{
    public class MainViewModel
    {
        private readonly ILocationServices _locationServices;

        public MainViewModel(ILocationServices locationServices)
        {
            _locationServices = locationServices;

            LoadData();
        }

        private async Task LoadData()
        {
            var response = await _locationServices.GetLocations(40.7, -74);

            var results = BackendToModelMapper.GetResults(response.Results);
        }
    }
}

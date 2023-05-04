using MVP.PrismMaui.Infrastructure.Abstractions;

namespace MVP.PrismMaui.ViewModels
{
    public class MainViewModel
    {
        private readonly ILocationServices _locationServices;

        public MainViewModel(ILocationServices locationServices)
        {
            _locationServices = locationServices;

            var p = _locationServices.GetLocations(40.7, -74);
        }
    }
}

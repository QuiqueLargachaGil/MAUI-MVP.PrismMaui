using MVP.PrismMaui.Infrastructure.Services.Locations;

namespace MVP.PrismMaui.Infrastructure.Abstractions
{
    public interface ILocationServices
    {
        Task<LocationsResponse> GetLocations(double latitude, double longitude);
    }
}

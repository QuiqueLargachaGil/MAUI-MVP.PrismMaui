using MVP.PrismMaui.Infrastructure.Services.Locations;

namespace MVP.PrismMaui.Infrastructure.Abstractions
{
    public interface ILocationServices
    {
        Task<LocationsResponse> GetLocations(double latitude, double longitude);

        //TODO: Declarar el nuevo miembro de la interfaz que va a obtener las fotos del servidor
    }
}

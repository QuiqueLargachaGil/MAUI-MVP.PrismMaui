using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Models;

namespace MVP.PrismMaui.ViewModels
{
    public class ResultDetailsViewModel : BindableBase, IInitializeAsync
    {
        private readonly ILocationServices _locationServices;

        // TODO: Variables privadas.

        public ResultDetailsViewModel(ILocationServices locationServices)
        {
            _locationServices = locationServices;            
        }

        public async Task InitializeAsync(INavigationParameters parameters)
        {
            var param = parameters.GetValue<Result>("SelectedResult");

            await LoadData(param.FsqId);
        }

        // TODO: Declarar la variable publica que contendrá la info a bindear con la vista 

        // TODO: Declarar la variable publica que contendrá la/s foto/s a bindear con la vista 

        private async Task LoadData(string id)
        {
            // TODO: Llamar al nuevo método del servicio para la obtención de fotos
            // Hacer el Mapper de la response
            // Asignar a la variable bindeada con la vista la/s imagen/es para mostrar por pantalla
        }
    }
}

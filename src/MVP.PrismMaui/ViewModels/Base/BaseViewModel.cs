using MVP.PrismMaui.Models.Exceptions;
using MVP.PrismMaui.Settings;

namespace MVP.PrismMaui.ViewModels.Base
{
	public class BaseViewModel : BindableBase, INavigatedAware
	{
		private readonly IPageDialogService _dialogService;
		private readonly IDialogService _dialogs;

		private string _title;
		private bool _isBusy;

		public BaseViewModel(IPageDialogService dialogService, IDialogService dialogs)
        {
            _dialogService = dialogService;
			_dialogs = dialogs;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
		{
			
		}

		public void OnNavigatedTo(INavigationParameters parameters)
		{
			OnNavigatedImplementation(parameters);
		}

		public virtual Task OnNavigatedImplementation(INavigationParameters parameters)
		{
			return Task.CompletedTask;
		}

		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}

		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}

		protected async Task HandleExceptions(Exception exception)
		{
			switch (exception)
			{
				case NoInternetException:
					await ShowAlertPopup(Configuration.ApplicationName, "No internet connection");
					break;
				default:
					await ShowAlertPopup(Configuration.ApplicationName, exception.Message);
					break;
			}
		}

		protected async Task ShowAlertPopup(string title, string message)
		{
			await _dialogService.DisplayAlertAsync(title, message, "Ok");

			// Tal y como se indica en la documentación de Prism, la interface IDialogService, aún no está disponible para MAUI
			//_dialog.ShowDialog("PRUEBA");
		}

		protected async Task<bool> ShowConfirmPopup(string title, string message)
		{
			return await _dialogService.DisplayAlertAsync(title, message, "Ok", "Cancel");
		}
	}
}

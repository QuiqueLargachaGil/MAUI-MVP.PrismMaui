using MVP.PrismMaui.Services.Abstractions;

namespace MVP.PrismMaui.ViewModels
{
    public class AboutViewModel : BindableBase
    {
        private readonly IVersionService _versionService;

        private string _version;

        public AboutViewModel(IVersionService versionService)
        {
            _versionService = versionService;
            LoadData();
        }

        public string Version
        {
            get => _version;
            set => SetProperty(ref _version, value);
        }

        private void LoadData()
        {
            Version = _versionService.GetVersion();
        }
    }
}

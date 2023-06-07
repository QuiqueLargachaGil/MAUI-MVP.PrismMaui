using MVP.PrismMaui.Services.Abstractions;

namespace MVP.PrismMaui.Services
{
    public class VersionService : IVersionService
    {
        public string GetVersion()
        {
            return VersionTracking.CurrentVersion;
        }
    }
}

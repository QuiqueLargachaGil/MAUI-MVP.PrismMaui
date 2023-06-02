using MVP.PrismMaui.Services.Abstractions;

namespace MVP.PrismMaui.Services
{
    public class CheckConnectivityService : ICheckConnectivityService
    {
        public Task<bool> HasInternetConnection()
        {
            var hasInternetConnection = Connectivity.NetworkAccess == NetworkAccess.Internet;
            return Task.FromResult(hasInternetConnection);
        }
    }
}

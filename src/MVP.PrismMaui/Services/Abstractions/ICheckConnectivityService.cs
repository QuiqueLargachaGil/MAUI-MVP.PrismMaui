namespace MVP.PrismMaui.Services.Abstractions
{
    public interface ICheckConnectivityService
    {
        Task<bool> HasInternetConnection();
    }
}

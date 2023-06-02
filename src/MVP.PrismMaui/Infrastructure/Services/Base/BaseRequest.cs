namespace MVP.PrismMaui.Infrastructure.Services.Base
{
    public abstract class BaseRequest
    {
        protected BaseRequest(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public string BaseUrl { get; }
    }
}

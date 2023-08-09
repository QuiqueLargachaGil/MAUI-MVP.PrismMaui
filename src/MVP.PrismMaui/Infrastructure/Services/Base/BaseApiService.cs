using MVP.PrismMaui.Models.Exceptions;
using MVP.PrismMaui.Services.Abstractions;
using Newtonsoft.Json;

namespace MVP.PrismMaui.Infrastructure.Services.Base
{
    public abstract class BaseApiService
    {
        private readonly ICheckConnectivityService _checkConnectivityService;
        private readonly HttpClientHandler _handler;

        protected BaseApiService(ICheckConnectivityService checkConnectivityService, HttpClientHandler handler)
        {
            _checkConnectivityService = checkConnectivityService;
            _handler = handler;
        }

        protected async Task<TResponse> HttpCall<TResponse, TRequest>(HttpMethod httpMethod, string endpoint, TRequest request) where TResponse : new() where TRequest : BaseRequest
        {
            if (!await _checkConnectivityService.HasInternetConnection())
            {
                throw new NoInternetException(nameof(NoInternetException));
            }

            var url = GetUrl(request.BaseUrl, endpoint);

            using (var client = GetHttpClient())
            {
                //var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
                //request.Headers.TryAddWithoutValidation("Authorization", "YourApiKey");
                //var response = await client.SendAsync(httpRequest);

                HttpResponseMessage response;
                switch (httpMethod)
                {
                    case HttpMethod method when method == HttpMethod.Get:
                        response = await client.GetAsync(url);//.ConfigureAwait(false);
                        break;
                    default:
                        throw new ArgumentException($"{nameof(httpMethod)} should be HttpMethod.Get");
                }

                if (!response.IsSuccessStatusCode)
                {
                    HandleApiException(response);
                }

                TResponse value;
                var jsonSerializer = GetJsonSerializer();

                using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var reader = new StreamReader(stream))
                using (var content = new JsonTextReader(reader))
                {
                    value = jsonSerializer.Deserialize<TResponse>(content);
                }

                return value ?? default(TResponse);
            }
        }

        private string GetUrl(string baseUrl, string endpoint)
        {
            return $"{baseUrl}{endpoint}";
        }

        private HttpClient GetHttpClient()
        {
            var timeSpan = new TimeSpan(0, 0, 90);

            return _handler is null
                ?
                new HttpClient
                {
                    Timeout = timeSpan
                }
                : new HttpClient(_handler, false)
                {
                    Timeout = timeSpan
                };
        }

        private void HandleApiException(HttpResponseMessage response)
        {
            /*switch (response.StatusCode)
            {

            }*/
        }

        private JsonSerializer GetJsonSerializer()
        {
            return new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
            };
        }
    }
}

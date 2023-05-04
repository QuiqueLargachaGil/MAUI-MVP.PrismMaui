using MVP.PrismMaui.Infrastructure.Abstractions;
using Newtonsoft.Json;

namespace MVP.PrismMaui.Infrastructure.Services.Locations
{
    public class LocationServices : ILocationServices
    {
        private const string SearchUbicationsEndpoint = "https://api.foursquare.com/v3/places/search?ll={0},{1}";
        public async Task<LocationsResponse> GetLocations(double latitude, double longitude)
        {
            LocationsResponse result = new LocationsResponse();

            var url = string.Format(SearchUbicationsEndpoint, latitude, longitude);

            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.TryAddWithoutValidation("Authorization", "YourApiKey");

                var response = await client.SendAsync(request);

                var json = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<LocationsResponse>(json);
            }

            return result;
        }
    }
}

using MVP.PrismMaui.Infrastructure.Services.Locations.Models;
using Newtonsoft.Json;

namespace MVP.PrismMaui.Infrastructure.Services.Locations
{
    public class LocationsResponse
    {
        [JsonProperty("Results")]
        public IEnumerable<ResultDto> Results { get; set; }
    }
}

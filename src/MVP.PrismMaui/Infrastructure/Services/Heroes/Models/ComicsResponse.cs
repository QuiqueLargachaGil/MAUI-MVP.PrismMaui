using Newtonsoft.Json;

namespace MVP.PrismMaui.Infrastructure.Services.Heroes.Models
{
    public class ComicsResponse
    {
        [JsonProperty("data")]
        public ComicDataDto Data { get; set; }
    }
}

using Newtonsoft.Json;

namespace MVP.PrismMaui.Infrastructure.Services.Heroes.Models
{
    public class HeroesResponse
    {
        [JsonProperty("data")]
        public HeroDataDto Data { get; set; }
    }
}

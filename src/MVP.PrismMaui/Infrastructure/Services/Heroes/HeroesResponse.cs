using MVP.PrismMaui.Infrastructure.Services.Heroes.Models;
using Newtonsoft.Json;

namespace MVP.PrismMaui.Infrastructure.Services.Heroes
{
    public class HeroesResponse
    {
        [JsonProperty("data")]
        public DataDto Data { get; set; }
    }
}

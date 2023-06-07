using Newtonsoft.Json;

namespace MVP.PrismMaui.Infrastructure.Services.Heroes.Models
{
    public class HeroDataDto
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public IEnumerable<HeroDto> Heroes { get; set; }
    }
}

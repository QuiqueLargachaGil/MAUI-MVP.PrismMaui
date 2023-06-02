using Newtonsoft.Json;

namespace MVP.PrismMaui.Infrastructure.Services.Heroes.Models
{
    public class HeroDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("thumbnail")]
        public ThumbnailDto Thumbnail { get; set; }

        [JsonProperty("resourceUri")]
        public string ResourceUri { get; set; }

        [JsonProperty("comics")]
        public ComicDto Comics { get; set; }

        [JsonProperty("series")]
        public SerieDto Series { get; set; }
    }
}

using Newtonsoft.Json;

namespace MVP.PrismMaui.Infrastructure.Services.Heroes.Models
{
    public class ComicDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("thumbnail")]
        public ThumbnailDto Thumbnail { get; set; }
    }
}

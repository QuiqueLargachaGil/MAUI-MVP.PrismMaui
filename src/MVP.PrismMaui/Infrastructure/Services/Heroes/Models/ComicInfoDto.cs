using Newtonsoft.Json;

namespace MVP.PrismMaui.Infrastructure.Services.Heroes.Models
{
    public class ComicInfoDto
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionUri { get; set; }

        [JsonProperty("items")]
        public IEnumerable<ItemDto> Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }
}

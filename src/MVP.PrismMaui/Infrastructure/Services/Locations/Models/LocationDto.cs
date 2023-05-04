namespace MVP.PrismMaui.Infrastructure.Services.Locations.Models
{
    public class LocationDto
    {
        public string address { get; set; }
        public string census_block { get; set; }
        public string country { get; set; }
        public string cross_street { get; set; }
        public string dma { get; set; }
        public string formatted_address { get; set; }
        public string locality { get; set; }
        public IList<string> neighborhood { get; set; }
        public string postcode { get; set; }
        public string region { get; set; }
    }
}

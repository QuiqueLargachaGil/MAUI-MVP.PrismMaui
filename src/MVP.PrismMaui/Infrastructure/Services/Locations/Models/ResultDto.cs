namespace MVP.PrismMaui.Infrastructure.Services.Locations.Models
{
    public class ResultDto
    {
        public string fsq_id { get; set; }
        public IList<CategoryDto> categories { get; set; }
        //public IList<Chain> chains { get; set; }
        public int distance { get; set; }
        //public Geocodes geocodes { get; set; }
        public string link { get; set; }
        public LocationDto location { get; set; }
        public string name { get; set; }
        //public RelatedPlaces related_places { get; set; }
        public string timezone { get; set; }
    }
}

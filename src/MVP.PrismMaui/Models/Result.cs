namespace MVP.PrismMaui.Models
{
    public class Result
    {
        public string FsqId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
    }
}

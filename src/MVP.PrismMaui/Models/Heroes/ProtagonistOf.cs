namespace MVP.PrismMaui.Models.Heroes
{
    public class ProtagonistOf
    {
        public int Available { get; set; }

        public string CollectionURI { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public int Returned { get; set; }
    }
}

namespace MVP.PrismMaui.Models.Heroes
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Modified { get; set; }

        public Thumbnail Thumbnail { get; set; }

        public ImageSource Photo { get; set; }

        public string ResourceUri { get; set; }

        public ProtagonistOf Comics { get; set; }

        public ProtagonistOf Series { get; set; }
    }
}

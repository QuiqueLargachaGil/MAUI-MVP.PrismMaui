using MVP.PrismMaui.Infrastructure.Mappers.Base;
using MVP.PrismMaui.Infrastructure.Services.Heroes.Models;
using MVP.PrismMaui.Models.Heroes;

namespace MVP.PrismMaui.Infrastructure.Mappers
{
    public class HeroMapper : MapperBase<HeroDto, Hero>
    {
        protected override Hero MapImpl(HeroDto source)
        {
            var hero = new Hero
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Modified = source.Modified,
                Thumbnail = GetThumbnail(source.Thumbnail),
                ResourceUri = source.ResourceUri,
                Comics = GetComics(source.Comics),
                Series = GetSeries(source.Series)
            };

            return hero;
        }

        private static Thumbnail GetThumbnail(ThumbnailDto thumbnailDto)
        {
            var thumbnail = new Thumbnail
            {
                Path = thumbnailDto.Path,
                Extension = thumbnailDto.Extension,
            };

            return thumbnail;
        }

        private static ProtagonistOf GetComics(ComicDto comicDto)
        {
            var protagonistOf = new ProtagonistOf
            {
                Available = comicDto.Available,
                CollectionURI = comicDto.CollectionUri,
                Items = comicDto.Items.Select(c => new Item
                {
                    ResourceUri = c.ResourceUri,
                    Name = c.Name,
                }) ?? new List<Item>(),
                Returned = comicDto.Returned,
            };

            return protagonistOf;
        }

        // TODO. Is it possible to unify this method with the previous??
        private static ProtagonistOf GetSeries(SerieDto serieDto)
        {
            var protagonistOf = new ProtagonistOf
            {
                Available = serieDto.Available,
                CollectionURI = serieDto.CollectionUri,
                Items = serieDto.Items.Select(c => new Item
                {
                    ResourceUri = c.ResourceUri,
                    Name = c.Name,
                }) ?? new List<Item>(),
                Returned = serieDto.Returned,
            };

            return protagonistOf;
        }
    }
}

using MVP.PrismMaui.Infrastructure.Mappers.Base;
using MVP.PrismMaui.Infrastructure.Services.Heroes.Models;
using MVP.PrismMaui.Models.Heroes;

namespace MVP.PrismMaui.Infrastructure.Mappers
{
    public class ComicCoverMapper : MapperBase<ComicDto, ComicCover>
    {
        protected override ComicCover MapImpl(ComicDto source)
        {
            var comicCover = new ComicCover
            {
                Title = source.Title,
                Thumbnail = GetThumbnail(source.Thumbnail),
                Cover = GetPhoto(source.Thumbnail)
            };

            return comicCover;
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

        private static ImageSource GetPhoto(ThumbnailDto thumbnailDto)
        {
            var imageUrl = $"{thumbnailDto.Path}.{thumbnailDto.Extension}";
            var photoSource = ImageSource.FromUri(new Uri(imageUrl));

            return photoSource;
        }
    }
}

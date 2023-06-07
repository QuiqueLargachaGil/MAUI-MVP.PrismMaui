using MVP.PrismMaui.Infrastructure.Services.Heroes;
using MVP.PrismMaui.Infrastructure.Services.Heroes.Models;
using MVP.PrismMaui.Models.Heroes;

namespace MVP.PrismMaui.Infrastructure.Mappers
{
    public static class BackendToModelMapper
    {
        public static IEnumerable<Hero> GetHeroes(HeroesResponse data)
        {
            if (data is null)
            {
                return Enumerable.Empty<Hero>();
            }

            var mapper = new HeroMapper();

            var heroList = new List<Hero>();
            foreach (var hero in data.Data.Heroes)
            {
                // To ensure that all heroes will have description
                if (!string.IsNullOrEmpty(hero.Description))
                {
                    heroList.Add(mapper.Map(hero));
                }
            }

            return heroList;
        }

        public static IEnumerable<ComicCover> GetComicsCover(ComicsResponse data)
        {
            if (data is null)
            {
                return Enumerable.Empty<ComicCover>();
            }

            var mapper = new ComicCoverMapper();

            var comicCoverList = new List<ComicCover>();
            foreach (var cover in data.Data.Comics)
            {
                comicCoverList.Add(mapper.Map(cover));
            }

            return comicCoverList;
        }
    }
}

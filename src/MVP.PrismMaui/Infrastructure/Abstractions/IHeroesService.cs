using MVP.PrismMaui.Infrastructure.Services.Heroes;
using MVP.PrismMaui.Infrastructure.Services.Heroes.Models;

namespace MVP.PrismMaui.Infrastructure.Abstractions
{
    public interface IHeroesService
    {
        Task<HeroesResponse> GetHeroes(HeroesRequest request);
        Task<ComicsResponse> GetComicsByHero(ComicsRequest request);
    }
}

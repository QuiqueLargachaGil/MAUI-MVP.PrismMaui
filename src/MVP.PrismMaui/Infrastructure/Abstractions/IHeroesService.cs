using MVP.PrismMaui.Infrastructure.Services.Heroes;

namespace MVP.PrismMaui.Infrastructure.Abstractions
{
    public interface IHeroesService
    {
        Task<HeroesResponse> GetHeroes(HeroesRequest request);
    }
}

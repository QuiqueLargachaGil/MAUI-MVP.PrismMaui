using MVP.PrismMaui.Infrastructure.Abstractions;
using MVP.PrismMaui.Infrastructure.Services.Base;
using MVP.PrismMaui.Infrastructure.Services.Heroes.Models;
using MVP.PrismMaui.Services.Abstractions;

namespace MVP.PrismMaui.Infrastructure.Services.Heroes
{
    public class HeroesService : BaseApiService, IHeroesService
    {
        private const string HeroesEndpoint = "/v1/public/characters?limit=100&ts=1&apikey={0}&hash={1}";

        public HeroesService(ICheckConnectivityService checkConnectivityService, HttpClientHandler handler) : base(checkConnectivityService, handler)
        {
            
        }

        public async Task<HeroesResponse> GetHeroes(HeroesRequest request)
        {
            var endpoint = $"{string.Format(HeroesEndpoint, "YourApiKey", "YourHash")}";//?{request.ToQueryString()}";
            return await HttpCall<HeroesResponse, HeroesRequest>(HttpMethod.Get, endpoint, request);//.ConfigureAwait(false);            
        }

        public async Task<ComicsResponse> GetComicsByHero(ComicsRequest request)
        {
            var endpoint = $"{request.AbsolutePath}?ts=1&apikey=YourApiKey&hash=YourHash";
            return await HttpCall<ComicsResponse, ComicsRequest>(HttpMethod.Get, endpoint, request);
        }
    }
}

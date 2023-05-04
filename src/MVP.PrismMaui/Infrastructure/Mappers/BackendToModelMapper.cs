using MVP.PrismMaui.Infrastructure.Services.Locations.Models;
using MVP.PrismMaui.Models;

namespace MVP.PrismMaui.Infrastructure.Mappers
{
    public class BackendToModelMapper
    {
        public static IEnumerable<Result> GetResults(IEnumerable<ResultDto> results)
        {
            if (results is null || !results.Any())
            {
                return Enumerable.Empty<Result>();
            }

            var mapper = new ResultMapper();
            return results.Select(r => mapper.Map(r));
        }
    }
}

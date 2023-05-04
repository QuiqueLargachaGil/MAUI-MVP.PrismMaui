using MVP.PrismMaui.Infrastructure.Mappers.Base;
using MVP.PrismMaui.Infrastructure.Services.Locations.Models;
using MVP.PrismMaui.Models;

namespace MVP.PrismMaui.Infrastructure.Mappers
{
    public class ResultMapper : BaseMapper<ResultDto, Result>
    {
        protected override Result MapImpl(ResultDto source)
        {
            var result = new Result
            {
                FsqId = source.fsq_id,
                Categories = source.categories.Select(c => new Category
                {
                    Id = c.id,
                    Name = c.name,
                }),
                Location = GetLocation(source.location),
                Name = source.name
            };

            return result;
        }

        private static Models.Location GetLocation(LocationDto l)
        {
            return new Models.Location
            {
                Address = l.address,
                Country = l.country,
                FormattedAddress = l.formatted_address,
                Locality = l.locality,
                Postcode = l.postcode,
                Region = l.region
            };
        }
    }
}

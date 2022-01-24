using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripleSix.Static.Common.Dto;
using TripleSix.Static.Common.Enums;
using TripleSix.Static.Data.Repositories;
using TripleSix.Core.Dto;
using TripleSix.Core.Extensions;
using TripleSix.Core.Services;

namespace TripleSix.Static.Middle.Services
{
    public class RegionService : BaseService,
        IRegionService
    {
        public CityRepository CityRepo { get; set; }

        public DistrictRepository DistrictRepo { get; set; }

        public WardRepository WardRepo { get; set; }

        public async Task<RegionDataDto[]> GetList(IIdentity identity, RegionFilterDto filter)
        {
            var result = new List<RegionDataDto>();

            if (filter.Type == RegionTypes.City)
            {
                var cities = await (await CityRepo.BuildQueryOfFilter(identity, filter))
                    .ToArrayAsync<RegionDataDto>(Mapper);
                result.AddRange(cities);

                if (filter.ListDistrict == true)
                {
                    foreach (var city in cities)
                    {
                        city.ListChildRegion = await GetList(identity, new RegionFilterDto
                        {
                            Type = RegionTypes.District,
                            ListWard = filter.ListWard,
                            ParentCode = city.Code,
                            IsDeleted = false,
                        });
                    }
                }
            }

            if (filter.Type == RegionTypes.District)
            {
                var districts = await (await DistrictRepo.BuildQueryOfFilter(identity, filter))
                    .ToArrayAsync<RegionDataDto>(Mapper);
                result.AddRange(districts);

                if (filter.ListWard == true)
                {
                    foreach (var district in districts)
                    {
                        district.ListChildRegion = await GetList(identity, new RegionFilterDto
                        {
                            Type = RegionTypes.Ward,
                            ParentCode = district.Code,
                            IsDeleted = false,
                        });
                    }
                }
            }

            if (filter.Type == RegionTypes.Ward)
            {
                var wards = await (await WardRepo.BuildQueryOfFilter(identity, filter))
                    .ToArrayAsync<RegionDataDto>(Mapper);
                result.AddRange(wards);
            }

            return result.ToArray();
        }
    }
}

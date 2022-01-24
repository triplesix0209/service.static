using TripleSix.Static.Common.Dto;
using TripleSix.Static.Common.Enums;
using TripleSix.Static.Data.Database.Entities;
using TripleSix.Core.Mappers;

namespace TripleSix.Static.Middle.Mappers
{
    public class RegionMapper : BaseMapper
    {
        public RegionMapper()
        {
            CreateMap<CityEntity, RegionDataDto>()
                .ForMember(d => d.Type, o => o.MapFrom(s => RegionTypes.City))
                .ForMember(d => d.IsDeleted, o => o.MapFrom(s => !s.IsActive))
                .ForMember(d => d.ListChildRegion, o => o.Ignore());

            CreateMap<DistrictEntity, RegionDataDto>()
                .ForMember(d => d.Type, o => o.MapFrom(s => RegionTypes.District))
                .ForMember(d => d.IsDeleted, o => o.MapFrom(s => !s.IsActive))
                .ForMember(d => d.ListChildRegion, o => o.Ignore());

            CreateMap<WardEntity, RegionDataDto>()
                .ForMember(d => d.Type, o => o.MapFrom(s => RegionTypes.Ward))
                .ForMember(d => d.IsDeleted, o => o.MapFrom(s => !s.IsActive))
                .ForMember(d => d.ListChildRegion, o => o.Ignore());
        }
    }
}

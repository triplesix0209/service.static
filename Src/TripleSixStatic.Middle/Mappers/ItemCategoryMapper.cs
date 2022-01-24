using TripleSix.Static.Common.Dto;
using TripleSix.Static.Data.Database.Entities;
using TripleSix.Core.Mappers;

namespace TripleSix.Static.Middle.Mappers
{
    public class ItemCategoryMapper : BaseMapper
    {
        public ItemCategoryMapper()
        {
            CreateMap<ItemCategoryEntity, ItemCategoryDataDto>()
                .ForMember(d => d.IsDeleted, o => o.MapFrom(s => false));
        }
    }
}

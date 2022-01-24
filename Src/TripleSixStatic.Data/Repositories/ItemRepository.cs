using TripleSix.Static.Data.Contexts;
using TripleSix.Static.Data.Database.Entities;
using TripleSix.Core.Repositories;

namespace TripleSix.Static.Data.Repositories
{
    public class ItemRepository : BaseRepository<ItemEntity>
    //IQueryBuilder<SaleItemEntity, RegionFilterDto>
    {
        public ItemRepository(DmclContext context)
            : base(context)
        {
        }
    }
}

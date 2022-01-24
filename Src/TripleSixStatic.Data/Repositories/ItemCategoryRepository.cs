using System.Linq;
using System.Threading.Tasks;
using TripleSix.Static.Common.Dto;
using TripleSix.Static.Data.Contexts;
using TripleSix.Static.Data.Database.Entities;
using Microsoft.EntityFrameworkCore;
using TripleSix.Core.Dto;
using TripleSix.Core.Extensions;
using TripleSix.Core.Repositories;

namespace TripleSix.Static.Data.Repositories
{
    public class ItemCategoryRepository : BaseRepository<ItemCategoryEntity>,
        IQueryBuilder<ItemCategoryEntity, ItemCategoryFilterDto>
    {
        public ItemCategoryRepository(DmclContext context)
            : base(context)
        {
        }

        public Task<IQueryable<ItemCategoryEntity>> BuildQuery(IIdentity identity, ItemCategoryFilterDto filter)
        {
            var query = BuildQuery();

            if (filter.Code.IsNotNullOrWhiteSpace())
                query = query.Where(x => EF.Functions.Like(x.Code, $"%{filter.Code}%"));
            if (filter.Name.IsNotNullOrWhiteSpace())
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Name}%"));

            if (filter.Search.IsNotNullOrWhiteSpace())
            {
                query = query.WhereOrs(
                    x => EF.Functions.Like(x.Code, $"%{filter.Search}%"),
                    x => EF.Functions.Like(x.Name, $"%{filter.Search}%"));
            }

            return Task.FromResult(query);
        }
    }
}

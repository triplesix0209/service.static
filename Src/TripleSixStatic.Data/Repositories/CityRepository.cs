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
    public class CityRepository : BaseRepository<CityEntity>,
        IQueryBuilder<CityEntity, RegionFilterDto>
    {
        public CityRepository(DmclContext context)
            : base(context)
        {
        }

        public Task<IQueryable<CityEntity>> BuildQuery(IIdentity identity, RegionFilterDto filter)
        {
            var query = BuildQuery();

            if (filter.IsDeleted.HasValue)
                query = query.Where(x => x.IsActive != filter.IsDeleted);

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

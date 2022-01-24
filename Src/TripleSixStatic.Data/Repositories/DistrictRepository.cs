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
    public class DistrictRepository : BaseRepository<DistrictEntity>,
        IQueryBuilder<DistrictEntity, RegionFilterDto>
    {
        public DistrictRepository(DmclContext context)
            : base(context)
        {
        }

        public Task<IQueryable<DistrictEntity>> BuildQuery(IIdentity identity, RegionFilterDto filter)
        {
            var query = BuildQuery();

            if (filter.IsDeleted.HasValue)
                query = query.Where(x => x.IsActive != filter.IsDeleted);
            if (filter.ParentCode.IsNotNullOrWhiteSpace())
                query = query.Where(x => x.CityCode == filter.ParentCode);

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

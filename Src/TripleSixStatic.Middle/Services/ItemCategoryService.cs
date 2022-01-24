using System.Threading.Tasks;
using TripleSix.Static.Common.Dto;
using TripleSix.Static.Data.Repositories;
using TripleSix.Core.Dto;
using TripleSix.Core.Extensions;
using TripleSix.Core.Services;

namespace TripleSix.Static.Middle.Services
{
    public class ItemCategoryService : BaseService,
        IItemCategoryService
    {
        public ItemCategoryRepository ItemCategoryRepo { get; set; }

        public async Task<ItemCategoryDataDto[]> GetList(IIdentity identity, ItemCategoryFilterDto filter)
        {
            var query = await ItemCategoryRepo.BuildQuery(identity, filter);

            return await query.ToArrayAsync<ItemCategoryDataDto>(Mapper);
        }
    }
}

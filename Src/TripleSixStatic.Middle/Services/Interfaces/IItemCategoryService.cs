using System.Threading.Tasks;
using TripleSix.Static.Common.Dto;
using TripleSix.Core.Dto;
using TripleSix.Core.Services;

namespace TripleSix.Static.Middle.Services
{
    public interface IItemCategoryService : IService
    {
        Task<ItemCategoryDataDto[]> GetList(IIdentity identity, ItemCategoryFilterDto filter);
    }
}

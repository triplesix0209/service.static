using System.Threading.Tasks;
using TripleSix.Core.Dto;
using TripleSix.Core.Services;
using TripleSix.Static.Common.Dto;

namespace TripleSix.Static.Middle.Services
{
    public interface ISettingService : IService
    {
        Task<SettingDataDto[]> GetList(IIdentity identity);
    }
}

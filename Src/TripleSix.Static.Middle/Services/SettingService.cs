using System.Threading.Tasks;
using TripleSix.Core.Dto;
using TripleSix.Static.Common.Dto;
using TripleSix.Static.Middle.Abstracts;

namespace TripleSix.Static.Middle.Services
{
    public class SettingService : CommonService,
        ISettingService
    {
        public Task<SettingDataDto[]> GetList(IIdentity identity)
        {
            throw new System.NotImplementedException();
        }
    }
}

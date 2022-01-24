using System.Threading.Tasks;
using TripleSix.Core.Dto;
using TripleSix.Core.Services;
using TripleSix.Static.Common.Dto;

namespace TripleSix.Static.Middle.Services
{
    public interface IUploadService : IService
    {
        Task<UploadResultDto[]> UploadFile(IIdentity identity, UploadInputDto input);
    }
}

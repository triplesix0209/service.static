using System.Threading.Tasks;
using TripleSix.Core.Dto;
using TripleSix.Core.Services;
using TripleSix.Static.Common.Dto;

namespace TripleSix.Static.Middle.Services
{
    public interface IFileService : IService
    {
        Task DeleteFile(IIdentity identity, FileDeleteInputDto input);
    }
}

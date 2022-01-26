using System.IO;
using System.Threading.Tasks;
using TripleSix.Core.Dto;
using TripleSix.Core.Extensions;
using TripleSix.Static.Common;
using TripleSix.Static.Common.Dto;
using TripleSix.Static.Middle.Abstracts;
using TripleSix.Static.Middle.Helpers;

namespace TripleSix.Static.Middle.Services
{
    public class FileService : CommonService,
        IFileService
    {
        public ISettingService SettingService { get; set; }

        public async Task DeleteFile(IIdentity identity, FileDeleteInputDto input)
        {
            #region [validate]

            var setting = await SettingService.Get(identity, true);
            ValidateHelper.ValidateKey(setting, input.Key);

            if (input.FilePath.IsNullOrWhiteSpace())
                throw new AppException(AppExceptions.ParameterInvalid, args: nameof(input.FilePath));

            #endregion

            var uploadFilePath = Path.Combine(setting.BaseUploadDir, input.FilePath);
            if (File.Exists(uploadFilePath))
                File.Delete(uploadFilePath);

            if (!Directory.Exists(setting.BaseCacheDir)) return;
            var cacheDirs = Directory.GetDirectories(setting.BaseCacheDir);
            foreach (var dir in cacheDirs)
            {
                var cacheFilePath = Path.Combine(dir, input.FilePath);
                if (File.Exists(cacheFilePath))
                    File.Delete(cacheFilePath);
            }
        }
    }
}

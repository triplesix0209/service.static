using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TripleSix.Core.Dto;
using TripleSix.Core.Extensions;
using TripleSix.Static.Common;
using TripleSix.Static.Common.Dto;
using TripleSix.Static.Middle.Abstracts;

namespace TripleSix.Static.Middle.Services
{
    public class SettingService : CommonService,
        ISettingService
    {
        protected const string _baseSetting = "Setting";

        public Task<SettingDataDto> Get(IIdentity identity, bool validateSetting = false)
        {
            var result = new SettingDataDto();
            result.DebugMode = Configuration.GetValue($"{_baseSetting}:DebugMode", false);
            result.BaseUploadDir = Configuration.GetValue<string>($"{_baseSetting}:BaseUploadDir", null);
            result.BaseCacheDir = Configuration.GetValue<string>($"{_baseSetting}:BaseCacheDir", null);
            result.SecretKey = Configuration.GetValue<string>($"{_baseSetting}:UploadSecretKey", null);
            result.DynamicKeyEnable = Configuration.GetValue($"{_baseSetting}:UploadDynamicKeyEnable", true);
            result.DynamicKeyTimelife = Configuration.GetValue($"{_baseSetting}:UploadDynamicKeyTimelife", 60);
            result.BaseResultUrl = Configuration.GetValue<string>($"{_baseSetting}:BaseResultUrl", null);
            result.AllowMineTypes = Configuration.GetValue<string>($"{_baseSetting}:AllowMineTypes", null)
                ?.Split(",");
            result.MaxFileSize = Configuration.GetValue<int?>($"{_baseSetting}:MaxFileSize", null);

            if (validateSetting)
            {
                if (result.BaseUploadDir.IsNullOrWhiteSpace())
                    throw new AppException(AppExceptions.SettingInvalid, args: nameof(result.BaseUploadDir));

                if (result.BaseCacheDir.IsNullOrWhiteSpace())
                    throw new AppException(AppExceptions.SettingInvalid, args: nameof(result.BaseCacheDir));

                if (result.DynamicKeyTimelife <= 0)
                    throw new AppException(AppExceptions.SettingInvalid, args: nameof(result.DynamicKeyTimelife));

                if (result.BaseResultUrl.IsNullOrWhiteSpace())
                    throw new AppException(AppExceptions.SettingInvalid, args: nameof(result.BaseResultUrl));
            }

            return Task.FromResult(result);
        }
    }
}

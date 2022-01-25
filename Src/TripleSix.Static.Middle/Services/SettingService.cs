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
            result.DebugMode = Configuration.GetValue<bool>($"{_baseSetting}:DebugMode", false);
            result.UploadSecretKey = Configuration.GetValue<string>($"{_baseSetting}:UploadSecretKey", null);
            result.UploadPinTimelife = Configuration.GetValue($"{_baseSetting}:UploadPinTimelife", 60);
            result.BaseResultUrl = Configuration.GetValue<string>($"{_baseSetting}:BaseResultUrl", null);
            result.AllowMineTypes = Configuration.GetValue<string>($"{_baseSetting}:AllowMineTypes", null)
                ?.Split(",");
            result.MaxFileSize = Configuration.GetValue<int?>($"{_baseSetting}:MaxFileSize", null);

            if (validateSetting)
            {
                if (result.UploadPinTimelife <= 0)
                    throw new AppException(AppExceptions.UploadPinTimelifeInvalid);

                if (result.BaseResultUrl.IsNullOrWhiteSpace())
                    throw new AppException(AppExceptions.BaseResultUrlInvalid);
            }

            return Task.FromResult(result);
        }
    }
}

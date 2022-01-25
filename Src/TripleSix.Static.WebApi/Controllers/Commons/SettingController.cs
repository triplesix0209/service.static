using System;
using System.Threading.Tasks;
using Google.Authenticator;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TripleSix.Core.Extensions;
using TripleSix.Core.WebApi.Results;
using TripleSix.Static.Common;
using TripleSix.Static.Common.Dto;
using TripleSix.Static.Middle.Services;
using TripleSix.Static.WebApi.Abstracts;

namespace TripleSix.Static.WebApi.Controllers.Commons
{
    [SwaggerTag("thiết lập")]
    public class SettingController : CommonController
    {
        public ISettingService SettingService { get; set; }

        [HttpGet]
        [SwaggerOperation("lấy danh sách thiết lập")]
        [SwaggerResponse(200, null, typeof(DataResult<SettingDataDto>))]
        public async Task<IActionResult> GetList()
        {
            var identity = GenerateIdentity<Identity>();
            var data = await SettingService.Get(identity, false);
            return DataResult(data);
        }

        [HttpGet("SecretKey")]
        [SwaggerOperation("lấy secret key", Description = "chỉ hoạt động ở Debug Mode")]
        [SwaggerResponse(200, null, typeof(DataResult<string>))]
        public async Task<IActionResult> GetSecretKey()
        {
            var identity = GenerateIdentity<Identity>();
            var setting = await SettingService.Get(identity, false);
            if (!setting.DebugMode) throw new AppException(AppExceptions.WorkOnlyDebugMode);
            if (setting.UploadSecretKey.IsNullOrWhiteSpace())
                return DataResult<string>(null);

            var factor = new TwoFactorAuthenticator();
            var setupInfo = factor.GenerateSetupCode("Static API", "triplesix0209@gmail.com", setting.UploadSecretKey, false);
            return DataResult(setupInfo.ManualEntryKey);
        }

        [HttpGet("UploadKey")]
        [SwaggerOperation("lấy danh sách upload key", Description = "chỉ hoạt động ở Debug Mode")]
        [SwaggerResponse(200, null, typeof(DataResult<string[]>))]
        public async Task<IActionResult> GetUploadKey()
        {
            var identity = GenerateIdentity<Identity>();
            var setting = await SettingService.Get(identity, false);
            if (!setting.DebugMode) throw new AppException(AppExceptions.WorkOnlyDebugMode);
            if (setting.UploadSecretKey.IsNullOrWhiteSpace())
                return DataResult<string>(null);

            var factor = new TwoFactorAuthenticator();
            var result = factor.GetCurrentPINs(setting.UploadSecretKey, TimeSpan.FromSeconds(setting.UploadPinTimelife));
            return DataResult(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Authenticator;
using TripleSix.Core.Dto;
using TripleSix.Core.Extensions;
using TripleSix.Static.Common;
using TripleSix.Static.Common.Dto;
using TripleSix.Static.Middle.Abstracts;

namespace TripleSix.Static.Middle.Services
{
    public class UploadService : CommonService,
        IUploadService
    {
        protected const string _uploadDir = "Uploads";

        public ISettingService SettingService { get; set; }

        public async Task<UploadResultDto[]> UploadFile(IIdentity identity, UploadInputDto input)
        {
            #region [skip cases]

            if (input.Files.IsNullOrEmpty())
                return Array.Empty<UploadResultDto>();

            #endregion

            #region [validate]

            var setting = await SettingService.Get(identity, true);

            if (!setting.AllowAnonymous)
            {
                if (!setting.UploadDynamicKey)
                {
                    if (input.Key != setting.UploadSecretKey)
                        throw new AppException(AppExceptions.KeyInvalid);
                }
                else
                {
                    var factor = new TwoFactorAuthenticator();
                    if (!factor.ValidateTwoFactorPIN(setting.UploadSecretKey, input.Key, TimeSpan.FromSeconds(setting.UploadDynamicKeyTimelife)))
                        throw new AppException(AppExceptions.KeyInvalid);
                }
            }

            if (setting.AllowMineTypes.IsNotNullOrEmpty())
            {
                var invalidFile = input.Files
                    .FirstOrDefault(file => !CheckMineType(file.ContentType, setting.AllowMineTypes));
                if (invalidFile is not null)
                    throw new AppException(AppExceptions.MineTypeNotAllow, args: invalidFile.ContentType);
            }

            if (setting.MaxFileSize.HasValue && setting.MaxFileSize > 0)
            {
                if (input.Files.Any(file => file.Length > setting.MaxFileSize))
                    throw new AppException(AppExceptions.FileSizeNotAllow, args: string.Format("{0:n1}MB", (double)setting.MaxFileSize / 1048576));
            }

            #endregion

            var now = DateTime.UtcNow;
            var result = new List<UploadResultDto>();
            foreach (var file in input.Files)
            {
                #region [generate file name]

                string fileName;
                if (input.GenerateFileName == true)
                    fileName = Guid.NewGuid().ToString("N").ToLower() + Path.GetExtension(file.FileName);
                else
                    fileName = file.FileName;

                #endregion

                #region [prepare]

                var uploadDir = Path.Combine(
                        _uploadDir,
                        file.ContentType.Split("/")[0],
                        now.Year.ToString(),
                        now.Month.ToString("00"),
                        now.Day.ToString("00"));

                if (!Directory.Exists(uploadDir))
                    Directory.CreateDirectory(uploadDir);

                var uploadUrl = $"{file.ContentType.Split("/")[0]}/{now.Year}/{now.Month.ToString("00")}/{now.Day.ToString("00")}";

                #endregion

                #region [write file]

                using var stream = File.Create(Path.Combine(uploadDir, fileName));
                await file.CopyToAsync(stream);

                #endregion

                result.Add(new UploadResultDto
                {
                    Url = new Uri($"{setting.BaseResultUrl}/{uploadUrl}/{fileName}"),
                });
            }

            return result.ToArray();
        }

        protected bool CheckMineType(string mineType, string[] allowedTypes)
        {
            var types = mineType.Split("/");
            return allowedTypes.Any(allowedType =>
            {
                if (mineType == allowedType) return true;

                var checkTypes = allowedType.Split("/");
                return (checkTypes[0] == "*" && checkTypes[1] == types[1])
                    || (checkTypes[0] == types[0] && checkTypes[1] == "*");
            });
        }
    }
}

using System;
using Google.Authenticator;
using TripleSix.Static.Common;
using TripleSix.Static.Common.Dto;

namespace TripleSix.Static.Middle.Helpers
{
    public static class ValidateHelper
    {
        public static void ValidateKey(SettingDataDto setting, string key)
        {
            if (setting.AllowAnonymous) return;

            if (setting.DynamicKeyEnable)
            {
                var factor = new TwoFactorAuthenticator();
                if (!factor.ValidateTwoFactorPIN(setting.SecretKey, key, TimeSpan.FromSeconds(setting.DynamicKeyTimelife)))
                    throw new AppException(AppExceptions.KeyInvalid);
            }
            else
            {
                if (key != setting.SecretKey)
                    throw new AppException(AppExceptions.KeyInvalid);
            }
        }
    }
}

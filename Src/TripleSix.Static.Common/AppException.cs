#pragma warning disable SA1201 // ElementsMustAppearInTheCorrectOrder

using TripleSix.Core.Attributes;
using TripleSix.Core.Exceptions;

namespace TripleSix.Static.Common
{
    public class AppException : BaseException
    {
        public AppException(
            int httpCode = 500,
            string code = "exception",
            string message = "unexpected exception",
            object detail = null)
            : base(httpCode, code, message, detail)
        {
        }

        public AppException(
            AppExceptions error,
            object detail = null,
            params object[] args)
            : base(error, detail, args)
        {
        }
    }

    public enum AppExceptions
    {
        [ErrorData(403, message: "this api only work on debug mode")]
        WorkOnlyDebugMode,

        [ErrorData(500, message: "setting '{0}' is invalid")]
        SettingInvalid,

        [ErrorData(400, message: "parameter '{0}' is invalid")]
        ParameterInvalid,

        [ErrorData(401, message: "key is invalid")]
        KeyInvalid,

        [ErrorData(400, message: "mine type {0} is not allowed")]
        MineTypeNotAllow,

        [ErrorData(400, message: "file size ({0}) is not allowed")]
        FileSizeNotAllow,
    }
}

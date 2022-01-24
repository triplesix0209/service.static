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
        [ErrorData(500, message: "setting 'baseResultUrl' is invalid")]
        BaseResultUrlInvalid,

        [ErrorData(400, message: "mine type {0} is not allowed")]
        MineTypeNotAllow,

        [ErrorData(400, message: "file size ({0}) is not allowed")]
        FileSizeNotAllow,
    }
}

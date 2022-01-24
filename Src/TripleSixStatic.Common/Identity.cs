using Microsoft.AspNetCore.Http;
using TripleSix.Core.Dto;

namespace TripleSix.Static.Common
{
    public class Identity : BaseIdentity
    {
        public Identity()
            : base()
        {
        }

        public Identity(HttpContext httpContext)
            : base(httpContext)
        {
            HttpContext = httpContext;
        }

        public HttpContext HttpContext { get; }
    }
}

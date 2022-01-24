using TripleSix.Static.Common;
using Microsoft.AspNetCore.Components;
using TripleSix.Core.Dto;
using TripleSix.Core.WebApi.Controllers;

namespace TripleSix.Static.WebApi.Abstracts
{
    [Route("[controller]")]
    public abstract class CommonController : BaseController
    {
        protected override IIdentity GenerateIdentity()
        {
            return new Identity(HttpContext);
        }
    }
}

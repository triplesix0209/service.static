using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TripleSix.Core.WebApi.Filters;
using TripleSix.Core.WebApi.Results;
using TripleSix.Static.Common;
using TripleSix.Static.Common.Dto;
using TripleSix.Static.Middle.Services;
using TripleSix.Static.WebApi.Abstracts;

namespace TripleSix.Static.WebApi.Controllers.Commons
{
    [SwaggerTag("upload")]
    public class UploadController : CommonController
    {
        public IUploadService UploadService { get; set; }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [SwaggerOperation("upload file")]
        [SwaggerResponse(200, null, typeof(DataResult<UploadResultDto[]>))]
        [ValidateModel]
        public async Task<IActionResult> UploadFile(UploadInputDto input)
        {
            var identity = GenerateIdentity<Identity>();
            var result = await UploadService.UploadFile(identity, input);
            return DataResult(result);
        }
    }
}

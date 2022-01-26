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
    [SwaggerTag("file")]
    public class FileController : CommonController
    {
        public IFileService FileService { get; set; }

        [HttpDelete]
        [SwaggerOperation("xóa file")]
        [SwaggerResponse(200, null, typeof(SuccessResult))]
        [ValidateModel]
        public async Task<IActionResult> DeleteFile(FileDeleteInputDto input)
        {
            var identity = GenerateIdentity<Identity>();
            await FileService.DeleteFile(identity, input);
            return SuccessResult();
        }
    }
}

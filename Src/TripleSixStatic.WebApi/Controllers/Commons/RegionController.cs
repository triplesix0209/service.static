using System.Threading.Tasks;
using TripleSix.Static.Common;
using TripleSix.Static.Common.Dto;
using TripleSix.Static.Middle.Services;
using TripleSix.Static.WebApi.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TripleSix.Core.WebApi.Results;

namespace TripleSix.Static.WebApi.Controllers.Commons
{
    [SwaggerTag("khu vực hành chính")]
    public class RegionController : CommonController
    {
        public IRegionService RegionService { get; set; }

        [HttpGet]
        [SwaggerOperation("lấy danh sách khu vực hành chính")]
        [SwaggerResponse(200, null, typeof(DataResult<RegionDataDto[]>))]
        public async Task<IActionResult> GetList(RegionFilterDto filter)
        {
            var identity = GenerateIdentity<Identity>();
            var data = await RegionService.GetList(identity, filter);
            return DataResult(data);
        }
    }
}

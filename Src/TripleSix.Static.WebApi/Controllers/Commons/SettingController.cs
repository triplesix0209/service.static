using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerResponse(200, null, typeof(DataResult<SettingDataDto[]>))]
        public async Task<IActionResult> GetList()
        {
            var identity = GenerateIdentity<Identity>();
            var data = await SettingService.GetList(identity);
            return DataResult(data);
        }
    }
}

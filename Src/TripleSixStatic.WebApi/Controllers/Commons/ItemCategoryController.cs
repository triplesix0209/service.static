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
    [SwaggerTag("danh mục sản phẩm")]
    public class ItemCategoryController : CommonController
    {
        public IItemCategoryService ItemCategoryService { get; set; }

        [HttpGet]
        [SwaggerOperation("lấy danh sách danh mục sản phẩm")]
        [SwaggerResponse(200, null, typeof(DataResult<ItemCategoryDataDto[]>))]
        public async Task<IActionResult> GetList(ItemCategoryFilterDto filter)
        {
            var identity = GenerateIdentity<Identity>();
            var data = await ItemCategoryService.GetList(identity, filter);
            return DataResult(data);
        }
    }
}

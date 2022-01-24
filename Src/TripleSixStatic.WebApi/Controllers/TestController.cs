using System.Linq;
using System.Threading.Tasks;
using TripleSix.Static.Common;
using TripleSix.Static.Data.Repositories;
using TripleSix.Static.WebApi.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace TripleSix.Static.WebApi.Controllers
{
    public class TestController : CommonController
    {
        public ItemRepository ItemRepo { get; set; }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var identity = GenerateIdentity<Identity>();
            var data = ItemRepo.Query.First();
            return DataResult(data);
        }
    }
}

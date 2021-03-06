using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAsyncBenchmark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("Sync")]
        public IActionResult GetSync()
        {
            Thread.Sleep(1000);
            return Ok();
        }
        [HttpGet]
        [Route("Async")]
        public async Task<IActionResult> GetAsync()
        {
            //deneme--*
            await Task.Delay(1000);
            return Ok();
        }
    }
}

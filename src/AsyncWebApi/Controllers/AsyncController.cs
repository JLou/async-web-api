using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class AsyncController : ControllerBase
    {
        // GET api/values
        [HttpGet("api/async")]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            await Task.Delay(2000);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("api/sync")]
        public ActionResult<string> Get()
        {
            Task.Delay(2000).Wait();
            return "value";
        }

        [HttpGet("api/test")]
        public ActionResult<string> Get2()
        {
            FireAndForget();
            return "toto";
        }

        private async void FireAndForget()
        {
            await Task.Delay(2000);
            throw new Exception();
        }
    }
}

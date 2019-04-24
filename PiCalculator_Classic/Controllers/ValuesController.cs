using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PiCalculator_Classic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values/5
        [HttpGet("{digits}")]
        public async Task<IActionResult> Get(int digits) {
            var pi = await Task.Run(() => PiCalculator.GetPi(digits));
            return Ok(pi);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] int digits) {
            var pi = await Task.Run(() => PiCalculator.GetPi(digits));
            return Ok(pi);
        }

    }
}

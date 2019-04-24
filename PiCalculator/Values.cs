using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MathLibary;

namespace PiCalculator
{
    public static class Values
    {
        [FunctionName("GetPi")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string decimalString = req.Query["decimals"];

            if(string.IsNullOrEmpty(decimalString)) {
                return new BadRequestObjectResult("Missing Decimals");
            }

            int digits;
            if(!int.TryParse(decimalString, out digits)) {
                return new BadRequestObjectResult("Invalid decimal parameter");
            }

            var pi = await Task.Run(() => MathLibary.PiCalculator.GetPi(digits));
            return new OkObjectResult(pi);
        }
    }
}

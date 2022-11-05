using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BezoekersService.Models;

namespace Calculation.Function
{
    public static class CalculationTrigger
    {
        [FunctionName("CalculationTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calc")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string request = await new StreamReader(req.Body).ReadToEndAsync();
            
            CalculationRequest data = JsonConvert.DeserializeObject<CalculationRequest>(request);
            CalculationResult calc = new CalculationResult();

            switch(data.Operator) {
                case '+':
                    calc.Result = data.Getal1 + data.Getal2;
                break;
                case '-':
                    calc.Result = data.Getal1 - data.Getal2;
                break;
                case ':':
                    calc.Result = data.Getal1 / data.Getal2;
                break;
                case '*':
                    calc.Result = data.Getal1 * data.Getal2;
                break;
            }


            return new OkObjectResult(calc.Result);
        }
    }
}

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

namespace Calc.Functions
{
    public static class CalculatorTrigger
    {
        [FunctionName("CalculatorTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "calc/{getal1}/{getal2}/{operation}")] HttpRequest req,
            ILogger log, int getal1, int getal2, char operation)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

           CalculationResult calc = new CalculationResult();

           calc.Operator = operation;
           
            switch(calc.Operator) {
                case '+':
                    calc.Result = getal1 + getal2;
                break;
                case '-':
                    calc.Result = getal1 - getal2;
                break;
                case '/':
                    calc.Result = getal1 / getal2;
                break;
                case '*':
                    calc.Result = getal1 * getal2;
                break;
                default:
                    log.LogInformation("Bad request invalid operator");
                break;
            }
            return new OkObjectResult(calc.Result);
        }
    }
}

using System;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Web.Http;

namespace Sebug.Function
{
    public static class IssuePassTrigger
    {
        [FunctionName("IssuePassTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string name = req.Query["name"];

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var nvc = HttpUtility.ParseQueryString(requestBody);

                string responseMessage = "Issuing pass for: " + nvc["first_name"] + " " + nvc["last_name"];

                return new OkObjectResult(responseMessage);
            }
            catch (Exception ex)
            {
                log.LogError(exception: ex, ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}

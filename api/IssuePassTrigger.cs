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

            log.LogInformation("Issue pass requested");

            string serviceAccountInfo = Environment.GetEnvironmentVariable("SERVICE_ACCOUNT_INFO");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var nvc = HttpUtility.ParseQueryString(requestBody);

            string responseMessage = "Issuing pass for: " + nvc["first_name"] + " " +
            nvc["last_name"] + ", the service account info length is " + serviceAccountInfo.Length;

            return new OkObjectResult(responseMessage);
        }
    }
}

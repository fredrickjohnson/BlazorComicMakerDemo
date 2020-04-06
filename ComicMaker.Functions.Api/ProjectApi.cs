using System.IO;
using System.Threading.Tasks;
using ComicMaker.Common.Services.Interfaces;
using ComicMaker.Projects.Handlers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ComicMaker.Functions.Api
{
    public class TestModel
    {
        public string Data { get; set; }
    }

    public class ProjectApi
    {
        //private IProjectHandler _projectHandler;
        private IConnectionString _connectionString;

        public ProjectApi(IConnectionString connectionString)
        {
            _connectionString = connectionString;
            //_projectHandler = projectHandler;
        }

        [FunctionName("ProjectGetList")]
        public IActionResult GetList(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "project")] HttpRequest req, ILogger log)
        {
            return new OkObjectResult(new TestModel{ Data = _connectionString.Get() });
            /*
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);*/
        }
    }
}

using System.Threading.Tasks;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Queries;
using ComicMaker.Functions.Api.Services.Implementations;
using ComicMaker.Projects.Commands;
using ComicMaker.Projects.Handlers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace ComicMaker.Functions.Api.Controllers
{
    public class ProjectController
    {
        private readonly IProjectHandler _projectHandler;

        public ProjectController(IProjectHandler projectHandler)
        {
            _projectHandler = projectHandler;
        }

        [FunctionName("ProjectGetList")]
        public async Task<IActionResult> GetList(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "project")]
            HttpRequest req, ILogger log)
        {
            return await CommandQueryFactory.Create<GetListQuery>(req, log)
                .OnSuccess(x => _projectHandler.GetAllForAccount(x));
        }

        [FunctionName("ProjectCreate")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "project")]
            HttpRequest req, ILogger log)
        {
            return await CommandQueryFactory.Create<CreateProjectCommand>(req, log)
                .OnSuccess(x => _projectHandler.Create(x));
        }

        [FunctionName("ProjectUpdate")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "project/{id}")]
            HttpRequest req, ILogger log, string id)
        {
            return await CommandQueryFactory.Create<UpdateProjectCommand>(req, log)
                .AddIdRouteParameter(id)
                .OnSuccess(x => _projectHandler.Update(x));
        }

        [FunctionName("ProjectDeleteById")]
        public async Task <IActionResult> DeleteById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "project/{id}")]
            HttpRequest req, ILogger log, string id)
        {
            return await CommandQueryFactory.Create<DeleteByIdCommand>(req, log)
                .AddIdRouteParameter(id)
                .OnSuccess(x => _projectHandler.Delete(x));
        }
    }
}

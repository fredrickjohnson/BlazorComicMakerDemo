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
    public class SceneController
    {
        private readonly ISceneHandler _sceneHandler;

        public SceneController(ISceneHandler sceneHandler)
        {
            _sceneHandler = sceneHandler;
        }

        [FunctionName("SceneGetList")]
        public async Task<IActionResult> GetList(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "project/{parentId}/scene")]
            HttpRequest req, ILogger log, string parentId)
        {
            return await CommandQueryFactory.Create<GetListByParentIdQuery>(req, log)
                .AddParentRouteParameter(parentId)
                .OnSuccess(x => _sceneHandler.GetAllFor(x));
        }

        [FunctionName("SceneCreate")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "project/{parentId}/scene")]
            HttpRequest req, ILogger log, string parentId)
        {
            return await CommandQueryFactory.Create<CreateSceneCommand>(req, log)
                .AddParentRouteParameter(parentId)
                .OnSuccess(x => _sceneHandler.Create(x));
        }

        [FunctionName("SceneUpdate")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "scene/{id}")]
            HttpRequest req, ILogger log, string id)
        {
            return await CommandQueryFactory.Create<UpdateSceneCommand>(req, log)
                .AddIdRouteParameter(id)
                .OnSuccess(x => _sceneHandler.Update(x));
        }

        [FunctionName("SceneDeleteById")]
        public async Task<IActionResult> DeleteById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "scene/{id}")]
            HttpRequest req, ILogger log, string id)
        {
            return await CommandQueryFactory.Create<DeleteByIdCommand>(req, log)
                .AddIdRouteParameter(id)
                .OnSuccess(x => _sceneHandler.Delete(x));
        }
    }
}
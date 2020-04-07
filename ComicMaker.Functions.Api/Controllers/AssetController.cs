using System.Threading.Tasks;
using ComicMaker.Accounts.Handlers.Interfaces;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Queries;
using ComicMaker.Functions.Api.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace ComicMaker.Functions.Api.Controllers
{
    public class AssetController
    {
        private readonly IAssetHandler _assetHandler;

        public AssetController(IAssetHandler assetHandler)
        {
            _assetHandler = assetHandler;
        }

        [FunctionName("AssetGetList")]
        public async Task<IActionResult> GetList(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "asset")]
            HttpRequest req, ILogger log)
        {
            return await CommandQueryFactory.Create<GetListQuery>(req, log)
                .OnSuccess(x => _assetHandler.GetAllForAccount(x));
        }

        /*
        [FunctionName("AssetCreate")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "asset")]
            HttpRequest req, ILogger log, string id)
        {
            return await CommandQueryFactory.Create<CreateAssetCommand>(req, log)
                .AddIdRouteParameter(id)
                .OnSuccess(x => _assetHandler.Create(x));
        }*/

        [FunctionName("AssetDeleteById")]
        public async Task<IActionResult> DeleteById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "asset/{id}")]
            HttpRequest req, ILogger log, string id)
        {
            return await CommandQueryFactory.Create<DeleteByIdCommand>(req, log)
                .AddIdRouteParameter(id)
                .OnSuccess(x => _assetHandler.Delete(x));
        }
    }
}
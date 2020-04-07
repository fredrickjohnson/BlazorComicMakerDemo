using System.Threading.Tasks;
using ComicMaker.Accounts.Commands;
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
    public class CharacterController
    {
        private readonly ICharacterHandler _characterHandler;

        public CharacterController(ICharacterHandler characterHandler)
        {
            _characterHandler = characterHandler;
        }

        [FunctionName("CharacterGetList")]
        public async Task<IActionResult> GetList(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "character")]
            HttpRequest req, ILogger log)
        {
            return await CommandQueryFactory.Create<GetListQuery>(req, log)
                .OnSuccess(x => _characterHandler.GetAllForAccount(x));
        }

        [FunctionName("CharacterCreate")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "character")]
            HttpRequest req, ILogger log)
        {
            return await CommandQueryFactory.Create<CreateCharacterCommand>(req, log)
                .OnSuccess(x => _characterHandler.Create(x));
        }

        [FunctionName("CharacterUpdate")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "character/{id}")]
            HttpRequest req, ILogger log, string id)
        {
            return await CommandQueryFactory.Create<UpdateCharacterCommand>(req, log)
                .AddIdRouteParameter(id)
                .OnSuccess(x => _characterHandler.Update(x));
        }

        [FunctionName("CharacterDeleteById")]
        public async Task<IActionResult> DeleteById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "character/{id}")]
            HttpRequest req, ILogger log, string id)
        {
            return await CommandQueryFactory.Create<DeleteByIdCommand>(req, log)
                .AddIdRouteParameter(id)
                .OnSuccess(x => _characterHandler.Delete(x));
        }
    }
}
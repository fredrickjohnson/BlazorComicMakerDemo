using System.Threading.Tasks;
using ComicMaker.Accounts.Commands;
using ComicMaker.Accounts.Handlers.Interfaces;
using ComicMaker.Functions.Api.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace ComicMaker.Functions.Api.Controllers
{
    public class AccountController
    {
        private readonly IAccountHandler _accountHandler;

        public AccountController(IAccountHandler accountHandler)
        {
            _accountHandler = accountHandler;
        }

        /*
        [FunctionName("AccountGetList")]
        public async Task<IActionResult> GetList(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "account")]
            HttpRequest req, ILogger log)
        {
            return await CommandQueryFactory.Create<GetListQuery>(req, log)
                .OnSuccess(x => _accountHandler.GetAllForAccount(x));
        }*/

        [FunctionName("AccountCreate")]
        public async Task<IActionResult> Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "account")]
            HttpRequest req, ILogger log)
        {
            return await CommandQueryFactory.Create<CreateAccountCommand>(req, log)
                .OnSuccess(x => _accountHandler.Create(x));
        }

        /*
        [FunctionName("AccountUpdate")]
        public async Task<IActionResult> Update(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "account/{id}")]
            HttpRequest req, ILogger log, string id)
        {
            return await CommandQueryFactory.Create<UpdateAccountCommand>(req, log)
                .AddIdRouteParameter(id)
                .OnSuccess(x => _accountHandler.Update(x));
        }

        [FunctionName("AccountDeleteById")]
        public async Task<IActionResult> DeleteById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "account/{id}")]
            HttpRequest req, ILogger log, string id)
        {
            return await CommandQueryFactory.Create<DeleteByIdCommand>(req, log)
                .AddIdRouteParameter(id)
                .OnSuccess(x => _accountHandler.Delete(x));
        }*/
    }
}
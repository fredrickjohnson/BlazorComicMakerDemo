using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;
using ComicMaker.Common.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Optional;

namespace ComicMaker.Functions.Api.Services.Implementations
{
    public class CommandQueryFactory<T> where T : CommandQueryBase,new()
    {
        private readonly ILogger _logger;
        private readonly HttpRequest _request;
        private readonly IList<RequestActionBase> _actions = new List<RequestActionBase>();


        public CommandQueryFactory(HttpRequest request, ILogger logger)
        {
            _request = request;
            _logger = logger;
        }
        
        public CommandQueryFactory<T> AddIdRouteParameter(string id)
        {
            _actions.Add(new RequestAction<IIdCommandQuery>(x => x.Id = id));
            return this;
        }

        public CommandQueryFactory<T> AddParentRouteParameter(string parent)
        {
            _actions.Add(new RequestAction<IParentIdCommandQuery>(x => x.ParentId = parent.ToLower()));
            return this;
        }

        public CommandQueryFactory<T> AddPageSizeAndCountQueryStringParameters()
        {
            _actions.Add(new RequestAction<GetPageQuery>(x =>
            {
                x.CurrentPage = int.Parse(_request.Query["currentPage"]);
                x.ItemsPerPage = int.Parse(_request.Query["itemsPerPage"]);
            }));
            return this;
        }

        private Credentials GetCredentials()
        {
            return new Credentials
            {
                AccountId = "a888df1c-b02d-42a4-8a8b-ef9364a35afd",
                UserId = "2bd70447-9cd0-4905-9b53-80c355bf4e81",
                UserName = "jburner@mailinator.com",
                Claims = new List<string> {"Admin"}
            };
        }

        private async  Task<Option<T>> CreateModel()
        {
            var model = new T();
            try
            {
                var method = _request.Method.ToUpper();
                if (method == "POST" || method == "PUT")
                {
                    var requestBody = await new StreamReader(_request.Body).ReadToEndAsync();
                    model = JsonConvert.DeserializeObject<T>(requestBody);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "");
                return Option.None<T>();
            }
            model.Credentials = GetCredentials();
            AutoRegister(model);
            foreach (var action in _actions)
            {
                action.Process(model);
            }
            return Option.Some<T>(model);
        }

        private void AutoRegister(T model)
        {
            if (model is IParentIdCommandQuery)
            {

            }
        }
 
        public async Task<IActionResult> OnSuccess<TResult>(Func<T, Option<TResult, ErrorResult>> func)
        {
            IActionResult results = new BadRequestObjectResult(new ErrorResult());
            var modelBuildingOption = await CreateModel();
            modelBuildingOption.MatchSome(x =>
            {
                var processOption = func(x);
                processOption.MatchSome(dataResult => results = new OkObjectResult(dataResult));
                processOption.MatchNone(errorResult => results = new BadRequestObjectResult(errorResult));
            });
            modelBuildingOption.MatchNone(() => results = new BadRequestObjectResult(new ErrorBuilder().Build()));
            return results;
        }
    }

    public class CommandQueryFactory
    {
        public static CommandQueryFactory<T> Create<T>(HttpRequest request, ILogger logger) where T : CommandQueryBase, new()
        {
            return new CommandQueryFactory<T>(request, logger);
        }
    }
}
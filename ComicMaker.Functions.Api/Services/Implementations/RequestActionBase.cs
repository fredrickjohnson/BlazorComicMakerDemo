using ComicMaker.Common.Commands;
using Microsoft.AspNetCore.Http;

namespace ComicMaker.Functions.Api.Services.Implementations
{
    public abstract class RequestActionBase
    {
        public abstract void Process(CommandQueryBase model);
    }
}
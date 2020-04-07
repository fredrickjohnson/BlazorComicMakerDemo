using System;
using ComicMaker.Common.Commands;

namespace ComicMaker.Functions.Api.Services.Implementations
{
    public class RequestAction<T> : RequestActionBase
    {
        private readonly Action<T> _action;

        public RequestAction(Action<T> action)
        {
            _action = action;
        }

        public override void Process(CommandQueryBase model)
        {
            if (model is T commandQueryBase)
            {
                _action.Invoke(commandQueryBase);
            }
        }
    }
}
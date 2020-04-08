using System;

namespace ComicMaker.Blazor.Shared.Common.Commands
{
    public class DeleteByIdCommand
    {
        public DeleteByIdCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
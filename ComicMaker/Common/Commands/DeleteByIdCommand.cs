using System;

namespace ComicMaker.Common.Commands
{
    public class DeleteByIdCommand : CommandQueryBase, IIdCommandQuery
    {
        public string Id { get; set; } = Guid.Empty.ToString();
    }
}

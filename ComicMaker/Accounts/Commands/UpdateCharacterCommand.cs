using System.Collections.Generic;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Services.Implementations;
using ComicMaker.Projects.Models;

namespace ComicMaker.Accounts.Commands
{
    public class UpdateCharacterCommand : CommandQueryBase, IIdCommandQuery
    {
        public string Id { get; set; } = IdFactory.Empty();
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<Part> Parts { get; set; } = new List<Part>();

    }
}
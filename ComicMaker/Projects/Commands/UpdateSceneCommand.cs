using System.Collections.Generic;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Services.Implementations;
using ComicMaker.Projects.Models;

namespace ComicMaker.Projects.Commands
{
    public class UpdateSceneCommand : CommandQueryBase, IIdCommandQuery
    {
        public string Id { get; set; } = IdFactory.Empty();

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string Background { get; set; }
        public string TopText { get; set; } = string.Empty;
        public int TopRows { get; set; }

        public string BottomText { get; set; } = string.Empty;
        public int BottomRows { get; set; }

        public IList<SceneElement> Elements { get; set; } = new List<SceneElement>();
    }
}
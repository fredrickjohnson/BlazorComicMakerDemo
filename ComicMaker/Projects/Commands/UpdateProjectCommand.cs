using ComicMaker.Common.Commands;
using ComicMaker.Common.Queries;

namespace ComicMaker.Projects.Commands
{
    public class UpdateProjectCommand : CommandQueryBase, IIdCommandQuery
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FontName { get; set; }

        public string FontSize { get; set; }

        public int RowHeight { get; set; }
    }
}
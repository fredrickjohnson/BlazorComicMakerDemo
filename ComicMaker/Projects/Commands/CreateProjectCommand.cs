using ComicMaker.Common.Commands;

namespace ComicMaker.Projects.Commands
{
    public class CreateProjectCommand : CommandQueryBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

using ComicMaker.Common.Commands;
using ComicMaker.Common.Services.Implementations;

namespace ComicMaker.Projects.Commands
{
    public class CreateSceneCommand : CommandQueryBase
    {
        public string ProjectId { get; set; } = IdFactory.Empty();
        public string Name { get; set; }
    }
}
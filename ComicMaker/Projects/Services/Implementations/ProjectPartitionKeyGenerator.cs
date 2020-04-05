using ComicMaker.Projects.Services.Interfaces;

namespace ComicMaker.Projects.Services.Implementations
{
    public class ProjectPartitionKeyGenerator : IProjectPartitionKeyGenerator
    {
        public string CreateSceneKey()
        {
            return "Scene";
        }

        public string CreateCharacterKey()
        {
            return "Character";
        }

        public string CreateProjectKey()
        {
            return "Project";
        }
    }
}
namespace ComicMaker.Projects.Services.Interfaces
{
    public interface IProjectPartitionKeyGenerator
    {
        string CreateSceneKey();
        string CreateCharacterKey();
        string CreateProjectKey();
    }
}

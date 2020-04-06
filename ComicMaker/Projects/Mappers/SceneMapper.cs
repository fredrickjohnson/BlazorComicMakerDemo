using ComicMaker.Projects.Commands;
using ComicMaker.Projects.Entities;
using ComicMaker.Projects.Models;
using ComicMaker.Projects.Services.Interfaces;
using Newtonsoft.Json;

namespace ComicMaker.Projects.Mappers
{
    public class SceneMapper
    {
        private readonly IProjectPartitionKeyGenerator _partitionKeyGenerator;

        public SceneMapper(IProjectPartitionKeyGenerator partitionKeyGenerator)
        {
            _partitionKeyGenerator = partitionKeyGenerator;
        }

        public static Scene Map(SceneEntity source)
        {
            return new Scene
            {
                Id = source.RowKey,
                Name = source.Name,
                Background = source.Background,
                BottomRows =  source.BottomRows,
                BottomText =  source.BottomText,
                TopRows = source.TopRows,
                TopText =  source.TopText,
            };
        }

        public SceneEntity Map(CreateSceneCommand source)
        {
            var destination = new SceneEntity
            {
                AccountId = source.Credentials.AccountId,
                ProjectId = source.ProjectId,
                Name = source.Name,
            };
            return destination;
        }

        public SceneEntity Map(UpdateSceneCommand source, SceneEntity destination)
        {
            destination.Name = source.Name;
            destination.Background = source.Background;
            destination.TopText = source.TopText;
            destination.TopRows = source.TopRows;
            destination.BottomText = source.BottomText;
            destination.BottomRows = source.BottomRows;
            destination.ElementsAsString = JsonConvert.SerializeObject(source.Elements);
            return destination;
        }
    }
}
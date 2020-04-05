using ComicMaker.Common.Services.Implementations;
using ComicMaker.Projects.Commands;
using ComicMaker.Projects.Entities;
using ComicMaker.Projects.Models;
using ComicMaker.Projects.Services.Interfaces;

namespace ComicMaker.Projects.Mappers
{
    public class ProjectMapper
    {
        private readonly IProjectPartitionKeyGenerator _partitionKeyGenerator;

        public ProjectMapper(IProjectPartitionKeyGenerator partitionKeyGenerator)
        {
            _partitionKeyGenerator = partitionKeyGenerator;
        }

        public static ProjectSummary Map(ProjectEntity source)
        {
            return new ProjectSummary
            {
                Id = source.RowKey,
                Name = source.Name
            };
        }

        public ProjectEntity Create(CreateProjectCommand source)
        {
            var destination = new ProjectEntity
            {
                RowKey = IdFactory.Create(),
                PartitionKey = _partitionKeyGenerator.CreateProjectKey(),
                Name = source.Name,
                Description = source.Description
            };
            return destination;
        }

        public ProjectEntity Update(UpdateProjectCommand source, ProjectEntity destination)
        {
            destination.Name = source.Name;
            destination.Description = source.Description;
            destination.FontName = source.FontName;
            destination.FontSize = source.FontSize;
            destination.RowHeight = source.RowHeight;
            return destination;
        }
    }
}

using ComicMaker.Common.Data;
using ComicMaker.Common.Services.Interfaces;
using ComicMaker.Projects.Data.Interfaces;
using ComicMaker.Projects.Entities;

namespace ComicMaker.Projects.Data.Implementations
{
    public class ProjectRepository : RepositoryBase<ProjectEntity>, IProjectRepository
    {
        public ProjectRepository(IConnectionString connectionString) : base(connectionString, Common.Data.Table.Project)
        {
        }
    }
}
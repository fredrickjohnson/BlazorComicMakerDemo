using ComicMaker.Common.Commands;
using ComicMaker.Projects.Entities;
using Optional;

namespace ComicMaker.Projects.Data.Interfaces
{
    public interface IProjectRepository
    {
        Option<ProjectEntity> GetById(IIdCommandQuery query);
        void Insert(ProjectEntity entity);
        void Update(ProjectEntity entity);
        void Delete(ProjectEntity entity);
    }
}

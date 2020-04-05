using System;
using System.Text;
using ComicMaker.Projects.Entities;

namespace ComicMaker.Projects.Data.Interfaces
{
    public interface IProjectRepository
    {
        void Insert(ProjectEntity entity);
        void Update(ProjectEntity entity);
        void Delete(ProjectEntity entity);
    }
}

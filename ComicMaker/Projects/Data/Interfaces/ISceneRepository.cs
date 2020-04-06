using ComicMaker.Common.Commands;
using ComicMaker.Projects.Entities;
using Optional;

namespace ComicMaker.Projects.Data.Interfaces
{
    public interface ISceneRepository
    {
        Option<SceneEntity> GetById(IIdCommandQuery query);
        void Insert(SceneEntity entity);
        void Update(SceneEntity entity);
        void Delete(SceneEntity entity);
    }
}
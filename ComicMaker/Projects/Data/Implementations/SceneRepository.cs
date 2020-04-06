using ComicMaker.Common.Data;
using ComicMaker.Common.Services.Interfaces;
using ComicMaker.Projects.Data.Interfaces;
using ComicMaker.Projects.Entities;

namespace ComicMaker.Projects.Data.Implementations
{
    public class SceneRepository : RepositoryBase<SceneEntity>, ISceneRepository
    {
        public SceneRepository(IConnectionString connectionString) : base(connectionString, Common.Data.Table.Scene)
        {
        }
    }
}
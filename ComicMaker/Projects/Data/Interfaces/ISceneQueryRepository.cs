using System.Collections.Generic;
using ComicMaker.Common.Queries;
using ComicMaker.Projects.Models;

namespace ComicMaker.Projects.Data.Interfaces
{
    public interface ISceneQueryRepository
    {
        IEnumerable<Scene> GetAllForProject(GetListByParentIdQuery query);
    }
}
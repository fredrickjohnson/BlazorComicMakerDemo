using System.Linq;
using System.Collections.Generic;
using ComicMaker.Common.Data;
using ComicMaker.Common.Queries;
using ComicMaker.Common.Services.Interfaces;
using ComicMaker.Projects.Data.Interfaces;
using ComicMaker.Projects.Entities;
using ComicMaker.Projects.Mappers;
using ComicMaker.Projects.Models;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Projects.Data.Implementations
{
    public class SceneQueryRepository : RepositoryBase, ISceneQueryRepository
    {
        public SceneQueryRepository(IConnectionString connectionString) : base(connectionString, Common.Data.Table.Scene)
        {
        }

        public IEnumerable<Scene> GetAllForProject(GetListByParentIdQuery query)
        {
            var tableQuery = new TableQuery<SceneEntity>();
            var results = tableQuery.Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition(nameof(SceneEntity.AccountId), QueryComparisons.Equal, query.Credentials.AccountId),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition(nameof(SceneEntity.ProjectId), QueryComparisons.Equal, query.ParentId)));
            return results.Select(SceneMapper.Map);
        }
    }
}
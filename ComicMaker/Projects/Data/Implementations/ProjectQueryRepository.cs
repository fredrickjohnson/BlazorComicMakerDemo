using System.Collections.Generic;
using System.Linq;
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
    public class ProjectQueryRepository : RepositoryBase, IProjectQueryRepository
    {
        public ProjectQueryRepository(IConnectionString connectionString) : base(connectionString,Common.Data.Table.Project)
        {

        }

        public IEnumerable<ProjectSummary> GetAllForAccount(GetListQuery query)
        {
            var tableQuery = new TableQuery<ProjectEntity>();
            var results = Table.ExecuteQuery(tableQuery.Where(TableQuery.GenerateFilterCondition(nameof(ProjectEntity.AccountId),QueryComparisons.Equal, query.Credentials.AccountId)));
            return results.Select(ProjectMapper.Map);
        }
    }
}

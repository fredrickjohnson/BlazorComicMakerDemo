using System.Linq;
using System.Collections.Generic;
using ComicMaker.Accounts.Data.Interfaces;
using ComicMaker.Accounts.Entities;
using ComicMaker.Accounts.Mappers;
using ComicMaker.Accounts.Models;
using ComicMaker.Common.Data;
using ComicMaker.Common.Queries;
using ComicMaker.Common.Services.Interfaces;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Accounts.Data.Implementations
{
    public class AssetQueryRepository : RepositoryBase, IAssetQueryRepository
    {
        public AssetQueryRepository(IConnectionString connectionString) : base(connectionString, Common.Data.Table.Asset)
        {
        }

        public IEnumerable<Asset> GetAllForAccount(GetListQuery query)
        {
            var tableQuery = new TableQuery<AssetEntity>();
            var results = Table.ExecuteQuery(tableQuery.Where(TableQuery.GenerateFilterCondition(nameof(AssetEntity.AccountId), QueryComparisons.Equal, query.Credentials.AccountId)));
            return results.Select(AssetMapper.Map);
        }
    }
}
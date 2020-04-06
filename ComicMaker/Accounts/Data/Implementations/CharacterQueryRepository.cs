using System.Linq;
using System.Collections.Generic;
using ComicMaker.Accounts.Data.Interfaces;
using ComicMaker.Accounts.Entities;
using ComicMaker.Common.Data;
using ComicMaker.Common.Queries;
using ComicMaker.Common.Services.Interfaces;
using ComicMaker.Projects.Mappers;
using ComicMaker.Projects.Models;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Accounts.Data.Implementations
{
    public class CharacterQueryRepository : RepositoryBase, ICharacterQueryRepository
    {
        public CharacterQueryRepository(IConnectionString connectionString) : base(connectionString, Common.Data.Table.Character)
        {
        }

        public IEnumerable<Character> GetAllForAccount(GetListQuery query)
        {
            var tableQuery = new TableQuery<CharacterEntity>();
            var results = tableQuery.Where(TableQuery.GenerateFilterCondition(nameof(CharacterEntity.AccountId), QueryComparisons.Equal, query.Credentials.AccountId));
            return results.Select(CharacterMapper.Map);
        }
    }
}
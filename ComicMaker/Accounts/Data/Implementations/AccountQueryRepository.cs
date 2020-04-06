using ComicMaker.Accounts.Data.Interfaces;
using ComicMaker.Accounts.Models;
using ComicMaker.Common.Data;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;
using ComicMaker.Common.Services.Interfaces;

namespace ComicMaker.Accounts.Data.Implementations
{
    public class AccountQueryRepository : RepositoryBase, IAccountQueryRepository
    {
        public AccountQueryRepository(IConnectionString connectionString) : base(connectionString, Common.Data.Table.Account)
        {
        }

        public PagedResult<AccountSummary> GetPage(GetPageQuery query)
        {
            throw new System.NotImplementedException();
        }
    }
}
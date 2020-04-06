using ComicMaker.Accounts.Models;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;

namespace ComicMaker.Accounts.Data.Interfaces
{
    public interface IAccountQueryRepository
    {
        PagedResult<AccountSummary> GetPage(GetPageQuery query);

        //AccountDetail
    }
}
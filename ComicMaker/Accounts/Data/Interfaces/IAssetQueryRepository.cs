using System.Collections.Generic;
using ComicMaker.Accounts.Models;
using ComicMaker.Common.Queries;

namespace ComicMaker.Accounts.Data.Interfaces
{
    public interface IAssetQueryRepository
    {
        IEnumerable<Asset> GetAllForAccount(GetListQuery query);
    }
}
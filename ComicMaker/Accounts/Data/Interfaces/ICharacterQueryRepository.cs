using System.Collections.Generic;
using ComicMaker.Common.Queries;
using ComicMaker.Projects.Models;

namespace ComicMaker.Accounts.Data.Interfaces
{
    public interface ICharacterQueryRepository
    {
        IEnumerable<Character> GetAllForAccount(GetListQuery query);
    }
}
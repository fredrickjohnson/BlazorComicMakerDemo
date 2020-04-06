using ComicMaker.Accounts.Entities;
using ComicMaker.Common.Commands;
using Optional;

namespace ComicMaker.Accounts.Data.Interfaces
{
    public interface IAccountRepository
    {
        Option<AccountEntity> GetById(IIdCommandQuery query);
        void Insert(AccountEntity entity);
        void Update(AccountEntity entity);
        void Delete(AccountEntity entity);
    }
}
using ComicMaker.Accounts.Entities;
using ComicMaker.Common.Commands;
using Optional;

namespace ComicMaker.Accounts.Data.Interfaces
{
    public interface IUserRepository
    {
        Option<UserEntity> GetById(IIdCommandQuery query);
        void Insert(UserEntity entity);
        void Update(UserEntity entity);
        void Delete(UserEntity entity);
    }
}

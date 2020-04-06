using ComicMaker.Accounts.Entities;
using ComicMaker.Common.Commands;
using Optional;

namespace ComicMaker.Accounts.Data.Interfaces
{
    public interface ICharacterRepository
    {
        Option<CharacterEntity> GetById(IIdCommandQuery query);
        void Insert(CharacterEntity entity);
        void Update(CharacterEntity entity);
        void Delete(CharacterEntity entity);
    }
}
using ComicMaker.Accounts.Entities;
using ComicMaker.Common.Commands;
using Optional;

namespace ComicMaker.Accounts.Data.Interfaces
{
    public interface IAssetRepository
    {
        Option<AssetEntity> GetById(IIdCommandQuery query);
        void Insert(AssetEntity entity);
        void Update(AssetEntity entity);
        void Delete(AssetEntity entity);
    }
}

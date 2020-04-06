using ComicMaker.Accounts.Entities;
using ComicMaker.Accounts.Models;

namespace ComicMaker.Accounts.Mappers
{
    public class AssetMapper
    {
        public static Asset Map(AssetEntity source)
        {
            return new Asset
            {
                Id = source.RowKey,
                Name = source.Name,
                Extension = source.Extension,
                FileSize = source.FileSize,
                FullPath = source.FullPath,
                Height = source.Height,
                Width = source.Width,
                Type = source.Type
            };
        }
    }
}
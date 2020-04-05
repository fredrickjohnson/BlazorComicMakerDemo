using System;
using ComicMaker.Accounts.Models;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Accounts.Entities
{
    public class AssetEntity : TableEntity
    {
        public Guid AccountId { get; set; } = Guid.Empty;
        public string FullPath { get; set; } = string.Empty;
        public string Type { get; set; } = AssetType.Image;
        public int FileSize { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }
    }
}
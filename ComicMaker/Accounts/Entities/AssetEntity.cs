using System;
using ComicMaker.Accounts.Models;
using ComicMaker.Common.Entities;
using ComicMaker.Common.Services.Implementations;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Accounts.Entities
{
    public class AssetEntity : TableEntity, IAccountEntity
    {
        public string AccountId { get; set; } = IdFactory.Empty();
        public string FullPath { get; set; } = string.Empty;
        public string Type { get; set; } = AssetType.Image;
        public int FileSize { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }
    }
}
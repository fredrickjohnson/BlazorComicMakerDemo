namespace ComicMaker.Accounts.Models
{
    public class Asset
    {
        public string Id { get; set; }
        public string FullPath { get; set; } = string.Empty;
        public string Type { get; set; } = AssetType.Image;
        public int FileSize { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }
    }
}
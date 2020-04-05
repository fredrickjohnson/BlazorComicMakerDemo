using System;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Projects.Entities
{
    public class ProjectEntity : TableEntity
    {
        public Guid AccountId { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public string Description { get; set; }
        public int Width { get; set; } = 800;
        public int Height { get; set; } = 450;
        public string Font { get; set; } = "Arial";
        public string FontSize { get; set; } = "2em";
        public int RowHeight { get; set; } = 30;
    }
}
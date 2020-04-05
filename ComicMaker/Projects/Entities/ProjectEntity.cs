using System;
using ComicMaker.Common.Services.Implementations;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Projects.Entities
{
    public class ProjectEntity : TableEntity
    {
        public string AccountId { get; set; } = IdFactory.Create();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Width { get; set; } = 800;
        public int Height { get; set; } = 450;
        public string FontName { get; set; } = "Arial";
        public string FontSize { get; set; } = "2em";
        public int RowHeight { get; set; } = 30;
    }
}
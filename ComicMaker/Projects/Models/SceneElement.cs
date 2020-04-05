using System;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Projects.Models
{
    public class SceneElement : TableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Order { get; set; }
        public Guid AccountId { get; set; } = Guid.Empty;
        public Guid ProjectId { get; set; } = Guid.Empty;
        public int X { get; set; }
        public int Y { get; set; }
    }
}
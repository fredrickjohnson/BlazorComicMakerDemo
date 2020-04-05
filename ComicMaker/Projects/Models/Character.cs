using System;
using System.Collections.Generic;

namespace ComicMaker.Projects.Models
{
    public class Character
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public Guid ProjectId { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IList<Part> Parts { get; set; } = new List<Part>();
    }
}
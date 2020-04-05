using System;
using System.Collections.Generic;

namespace ComicMaker.Projects.Models
{
    public class Part
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public IList<NamePath> Images { get; set; } = new List<NamePath>();
    }
}

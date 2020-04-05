using System;
using System.Collections.Generic;
using ComicMaker.Common.Services.Implementations;

namespace ComicMaker.Projects.Models
{
    public class Character
    {
        public string Id { get; set; } = IdFactory.Create();
        public string ProjectId { get; set; } = IdFactory.Create();

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IList<Part> Parts { get; set; } = new List<Part>();
    }
}
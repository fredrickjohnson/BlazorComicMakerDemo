using System;
using System.Collections.Generic;

namespace ComicMaker.Projects.Models
{
    public class Scene
    {
        public Guid Id { get; set; } = Guid.Empty;

        public Guid ProjectId { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;

        public string TopText { get; set; } = string.Empty;
        public string BottomText { get; set; } = string.Empty;

        public int TopRows { get; set; } = 0;
        public int BottomRows { get; set; } = 0;

        public string Background { get; set; }

        public IList<SceneElement> Elements { get; set; } = new List<SceneElement>();
    }
}
using ComicMaker.Common.Services.Implementations;

namespace ComicMaker.Projects.Models
{
    public class Project
    {
        public string Id { get; set; } = IdFactory.Create();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Width { get; set; } = 800;
        public int Height { get; set; } = 450;
        public string FontName { get; set; } = "Arial";
        public string FontSize { get; set; } = "2em";
        public int RowHeight { get; set; } = 30;
    }
}
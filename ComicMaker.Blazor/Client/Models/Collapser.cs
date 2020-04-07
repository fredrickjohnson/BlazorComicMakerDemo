namespace ComicMaker.Blazor.Client.Models
{
    public class Collapser
    {
        public bool Show { get; set; }

        public void Toggle()
        {
            Show = !Show;
        }
    }
}
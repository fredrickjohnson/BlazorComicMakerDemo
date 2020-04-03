namespace ComicMaker.Blazor.Client.Services
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
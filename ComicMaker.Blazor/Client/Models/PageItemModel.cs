namespace ComicMaker.Blazor.Client.Models
{
    public class PageItemModel
    {
        public string Text { get; set; }
        public int Page { get; set; }

        public PageItemModel(int page)
        {
            Page = page;
            Text = page.ToString();
        }
    }
}
namespace ComicMaker.Blazor.Shared.Common.Queries
{
    public class GetPageQuery
    {
        public int ItemsPerPage { get; set; } = 10;

        public int CurrentPage { get; set; } = 1;
    }
}
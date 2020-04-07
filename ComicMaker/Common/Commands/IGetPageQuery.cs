namespace ComicMaker.Common.Commands
{
    public interface IGetPageQuery
    {
        int CurrentPage { get; set; }
        int ItemsPerPage { get; set; }
    }
}
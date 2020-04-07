using ComicMaker.Common.Commands;

namespace ComicMaker.Common.Queries
{
    public class GetPageQuery : CommandQueryBase, IGetPageQuery
    {
        public int ItemsPerPage { get; set; } = 10;

        public int CurrentPage { get; set; } = 1;
    }
}
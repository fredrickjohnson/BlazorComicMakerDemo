using ComicMaker.Common.Commands;

namespace ComicMaker.Common.Queries
{
    public class GetPageByParentIdQuery : CommandQueryBase
    {
        public string ParentId { get; set; }
        public int ItemsPerPage { get; set; } = 10;
        public int CurrentPage { get; set; } = 1;
    }
}
using ComicMaker.Common.Commands;

namespace ComicMaker.Common.Queries
{
    public class GetPageByParentIdQuery : CommandQueryBase, IParentIdCommandQuery, IGetPageQuery
    {
        public string ParentId { get; set; }
        public int ItemsPerPage { get; set; } = 10;
        public int CurrentPage { get; set; } = 1;
    }
}
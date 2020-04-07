using ComicMaker.Common.Commands;

namespace ComicMaker.Common.Queries
{
    public class GetListByParentIdQuery : CommandQueryBase, IParentIdCommandQuery
    {
        public string ParentId { get; set; }
    }
}
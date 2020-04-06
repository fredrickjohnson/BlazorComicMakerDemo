using ComicMaker.Common.Commands;

namespace ComicMaker.Common.Queries
{
    public class GetListByParentIdQuery : CommandQueryBase
    {
        public string ParentId { get; set; }
    }
}
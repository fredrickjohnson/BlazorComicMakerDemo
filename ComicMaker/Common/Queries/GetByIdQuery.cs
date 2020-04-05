using ComicMaker.Common.Commands;

namespace ComicMaker.Common.Queries
{
    public class GetByIdQuery : CommandQueryBase, IIdCommandQuery
    {
        public string Id { get; set; }
    }
}
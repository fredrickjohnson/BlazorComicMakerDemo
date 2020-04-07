using ComicMaker.Common.Commands;

namespace ComicMaker.Common.Queries
{
    public class GetAutoCompleteQuery : CommandQueryBase, IGetAutoCompleteQuery
    {
        public string Query { get; set; }
    }
}

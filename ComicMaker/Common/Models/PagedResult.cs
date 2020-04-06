using System.Collections.Generic;

namespace ComicMaker.Common.Models
{
    public class PagedResult<T>
    {
        public IList<T> Items { get; set; } = new List<T>();
        public long CurrentPage { get; set; }
        public long TotalPages { get; set; }
        public long TotalItems { get; set; }
        public long ItemsPerPage { get; set; }
    }
}
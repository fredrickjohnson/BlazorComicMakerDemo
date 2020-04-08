using System.Collections.Generic;

namespace ComicMaker.Blazor.Shared.Common.Models
{
    public class PagedResult
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
    }

    public class PagedResult<T> : PagedResult
    {
        public IList<T> Items { get; set; } = new List<T>();
        
    }
}
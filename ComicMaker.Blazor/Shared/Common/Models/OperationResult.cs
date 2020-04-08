using System.Collections.Generic;

namespace ComicMaker.Blazor.Shared.Common.Models
{
    public class OperationResult
    {
        public ResponseStatus Status { get; set; }
        public IList<ErrorMessage> Errors { get; set; }

        public OperationResult()
        {
            Errors = new List<ErrorMessage>();
        }
    }

    public abstract class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }
    }
}
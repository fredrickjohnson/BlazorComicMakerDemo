using System.Collections.Generic;

namespace ComicMaker.Common.Models
{
    public abstract class OperationResult
    {
        public ResponseStatus Status { get; set; }
        public IList<ErrorMessage> Errors { get; set; }

        protected OperationResult()
        {
            Errors = new List<ErrorMessage>();
        }
    }

    public abstract class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }
    }
}
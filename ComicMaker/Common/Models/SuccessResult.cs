using System;

namespace ComicMaker.Common.Models
{
    public class SuccessResult : OperationResult
    {
        public Guid Id { get; set; } = Guid.Empty;
        public SuccessResult()
        {
            Status = ResponseStatus.Success;
        }
    }
}

namespace ComicMaker.Blazor.Shared.Common.Models
{
    public class ErrorResult : OperationResult
    {
        public ErrorResult()
        {
            Status = ResponseStatus.Failed;
        }
        public ErrorResult AddErrorWithCode(string errorCode, string text)
        {
            Errors.Add(new ErrorMessage
            {
                Code = errorCode,
                Text = text
            });
            return this;
        }

        public ErrorResult AddErrorWithCodeAndName(string errorCode, string name, string text)
        {
            Errors.Add(new ErrorMessage
            {
                Code = errorCode,
                Name = name,
                Text = text
            });
            return this;
        }

        public ErrorResult AddErrorWithName(string name, string text)
        {
            Errors.Add(new ErrorMessage
            {
                Name = name,
                Text = text
            });
            return this;
        }
    }
}
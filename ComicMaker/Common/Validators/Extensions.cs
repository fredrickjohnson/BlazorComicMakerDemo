using System;
using ComicMaker.Common.Models;
using FluentValidation.Results;
using Optional;

namespace ComicMaker.Common.Validators
{
    public static class Extensions
    {
        public static ErrorMessage ToErrorMessage(this ValidationFailure message)
        {
            return new ErrorMessage
            {
                Text = message.ErrorMessage,
                Code = message.ErrorCode,
                Name = message.PropertyName
            };
        }

        public static Option<SuccessResult, ErrorResult> OnSuccess(this ValidationResult errorResults, Action<ErrorBuilder> onValid)
        {
            var errorBuilder = new ErrorBuilder();
            if (errorResults.IsValid)
            {
                onValid(errorBuilder);
            }
            else
            {
                errorBuilder.Append(errorResults.Errors);
            }
            return errorBuilder.HasErrors ? Option.None<SuccessResult, ErrorResult>(errorBuilder.Build()) : Option.Some<SuccessResult, ErrorResult>(new SuccessResult());
        }

        public static Option<SuccessResult, ErrorResult> OnSuccess(this ValidationResult errorResults, Func<ErrorBuilder, Guid> onValid)
        {
            var id = Guid.Empty;
            var errorBuilder = new ErrorBuilder();
            if (errorResults.IsValid)
            {
                id = onValid(errorBuilder);
            }
            else
            {
                errorBuilder.Append(errorResults.Errors);
            }
            return errorBuilder.HasErrors ? Option.None<SuccessResult, ErrorResult>(errorBuilder.Build()) : Option.Some<SuccessResult, ErrorResult>(new SuccessResult { Id = id });
        }

        public static Option<T, ErrorResult> OnSuccess<T>(this ValidationResult errorResults, Func<ErrorBuilder, T> onValid)
        {
            var results = default(T);
            var errorBuilder = new ErrorBuilder();
            if (errorResults.IsValid)
            {
                results = onValid(errorBuilder);
            }
            else
            {
                errorBuilder.Append(errorResults.Errors);
            }
            return errorBuilder.HasErrors ? Option.None<T, ErrorResult>(errorBuilder.Build()) : Option.Some<T, ErrorResult>(results);
        }
    }
}
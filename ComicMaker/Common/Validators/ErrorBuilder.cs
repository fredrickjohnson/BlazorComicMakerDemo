using System;
using System.Collections.Generic;
using ComicMaker.Common.Models;
using FluentValidation.Results;

namespace ComicMaker.Common.Validators
{
    public class ErrorBuilder
    {
        private readonly ErrorResult _errorResult = new ErrorResult();

        public bool HasErrors => _errorResult.Errors.Count > 0;

        public ErrorBuilder Append(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                _errorResult.Errors.Add(error.ToErrorMessage());
            }
            return this;
        }

        public ErrorBuilder Append(Exception ex)
        {

            return this;
        }

        public ErrorResult Build()
        {
            return _errorResult;
        }

        public void AddRecordNotFound()
        {
            _errorResult.Errors.Add(new ErrorMessage
            {
                Code = ErrorCode.ToastError,
                Text = "Record Not Found or Access Not Granted"
            });
        }

        public void AddToastError(string message)
        {
            _errorResult.Errors.Add(new ErrorMessage
            {
                Code = ErrorCode.ToastError,
                Text = message
            });
        }

        public void AddToastInfo(string message)
        {
            _errorResult.Errors.Add(new ErrorMessage
            {
                Code = ErrorCode.ToastInfo,
                Text = message
            });
        }
    }
}
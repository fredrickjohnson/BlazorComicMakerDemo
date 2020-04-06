using ComicMaker.Common.Commands;
using FluentValidation;

namespace ComicMaker.Common.Validators
{
    public class DeleteByIdCommandValidator : AbstractValidator<DeleteByIdCommand>
    {
        public DeleteByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Credentials.UserId).NotEmpty();
        }
    }
}

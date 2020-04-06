using ComicMaker.Accounts.Commands;
using FluentValidation;

namespace ComicMaker.Accounts.Validators
{
    public class RemoveUserFromAccountCommandValidator : AbstractValidator<RemoveUserFromAccountCommand>
    {
        public RemoveUserFromAccountCommandValidator()
        {

        }
    }
}
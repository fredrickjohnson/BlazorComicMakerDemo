using ComicMaker.Accounts.Commands;
using FluentValidation;

namespace ComicMaker.Accounts.Validators
{
    public class AddUserToAccountCommandValidator : AbstractValidator<AddUserToAccountCommand>
    {
        public AddUserToAccountCommandValidator()
        {

        }
    }
}
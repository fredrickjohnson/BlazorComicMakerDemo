using ComicMaker.Accounts.Commands;
using ComicMaker.Projects.Commands;
using FluentValidation;

namespace ComicMaker.Accounts.Validators
{
    public class UpdateCharacterCommandValidator : AbstractValidator<UpdateCharacterCommand>
    {
        public UpdateCharacterCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
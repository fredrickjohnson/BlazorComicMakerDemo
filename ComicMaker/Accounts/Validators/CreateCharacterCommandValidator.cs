using ComicMaker.Accounts.Commands;
using ComicMaker.Projects.Commands;
using FluentValidation;

namespace ComicMaker.Accounts.Validators
{
    public class CreateCharacterCommandValidator : AbstractValidator<CreateCharacterCommand>
    {
        public CreateCharacterCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
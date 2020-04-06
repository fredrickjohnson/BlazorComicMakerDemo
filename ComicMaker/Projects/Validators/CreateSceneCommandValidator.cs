using ComicMaker.Projects.Commands;
using FluentValidation;

namespace ComicMaker.Projects.Validators
{
    public class CreateSceneCommandValidator : AbstractValidator<CreateSceneCommand>
    {
        public CreateSceneCommandValidator()
        {
            //RuleFor(x => x.AccountId).NotEmpty();
        }
    }
}
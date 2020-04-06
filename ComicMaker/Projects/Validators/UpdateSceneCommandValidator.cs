using ComicMaker.Projects.Commands;
using FluentValidation;

namespace ComicMaker.Projects.Validators
{
    public class UpdateSceneCommandValidator : AbstractValidator<UpdateSceneCommand>
    {
        public UpdateSceneCommandValidator()
        {
            //RuleFor(x => x.AccountId).NotEmpty();
        }
    }
}
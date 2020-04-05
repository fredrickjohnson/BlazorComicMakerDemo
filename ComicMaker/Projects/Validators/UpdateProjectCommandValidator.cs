using ComicMaker.Projects.Commands;
using FluentValidation;

namespace ComicMaker.Projects.Validators
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
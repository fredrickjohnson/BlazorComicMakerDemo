using System;
using System.Collections.Generic;
using System.Text;
using ComicMaker.Projects.Commands;
using FluentValidation;

namespace ComicMaker.Projects.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            //RuleFor(x => x.AccountId).NotEmpty();
        }
    }
}

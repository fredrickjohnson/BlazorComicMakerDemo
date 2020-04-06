using System;
using System.Collections.Generic;
using System.Text;
using ComicMaker.Accounts.Commands;
using FluentValidation;

namespace ComicMaker.Accounts.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}

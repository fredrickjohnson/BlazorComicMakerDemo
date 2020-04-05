using ComicMaker.Common.Queries;
using FluentValidation;

namespace ComicMaker.Common.Validators
{
    public class GetAutoCompleteQueryValidator : AbstractValidator<GetAutoCompleteQuery>
    {
        public GetAutoCompleteQueryValidator()
        {
            RuleFor(x => x.Credentials.UserId).NotEmpty();
        }
    }
}
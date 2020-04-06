using ComicMaker.Common.Queries;
using FluentValidation;

namespace ComicMaker.Common.Validators
{
    public class GetPageQueryValidator : AbstractValidator<GetPageQuery>
    {
        public GetPageQueryValidator()
        {
            RuleFor(x => x.Credentials.UserId).NotEmpty();
            RuleFor(x => x.CurrentPage).GreaterThanOrEqualTo(1);
            RuleFor(x => x.ItemsPerPage).GreaterThanOrEqualTo(5);
        }
    }
}
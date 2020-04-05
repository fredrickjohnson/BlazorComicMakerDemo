using ComicMaker.Common.Queries;
using FluentValidation;

namespace ComicMaker.Common.Validators
{
    public class GetPagedQueryValidator : AbstractValidator<GetPagedQuery>
    {
        public GetPagedQueryValidator()
        {
            RuleFor(x => x.Credentials.UserId).NotEmpty();
        }
    }
}
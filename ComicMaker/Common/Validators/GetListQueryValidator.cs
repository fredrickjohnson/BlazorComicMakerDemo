using ComicMaker.Common.Queries;
using FluentValidation;

namespace ComicMaker.Common.Validators
{
    public class GetListQueryValidator : AbstractValidator<GetListQuery>
    {
        public GetListQueryValidator()
        {
            RuleFor(x => x.Credentials.UserId).NotEmpty();
        }
    }
}
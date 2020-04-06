using ComicMaker.Common.Queries;
using FluentValidation;

namespace ComicMaker.Common.Validators
{
    public class GetListByParentIdQueryValidator : AbstractValidator<GetListByParentIdQuery>
    {
        public GetListByParentIdQueryValidator()
        {
            RuleFor(x => x.Credentials.UserId).NotEmpty();
            RuleFor(x => x.ParentId).NotEmpty();
        }
    }
}
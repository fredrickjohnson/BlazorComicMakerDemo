using ComicMaker.Common.Commands;
using ComicMaker.Common.Models;
using ComicMaker.Projects.Commands;
using Optional;

namespace ComicMaker.Projects.Handlers.Interfaces
{
    public interface IProjectHandler
    {
        Option<SuccessResult, ErrorResult> Create(CreateProjectCommand command);
        Option<SuccessResult, ErrorResult> Update(UpdateProjectCommand command);
        Option<SuccessResult, ErrorResult> Delete(DeleteByIdCommand command);
    }
}

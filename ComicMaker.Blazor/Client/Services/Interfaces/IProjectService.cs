using System.Collections.Generic;
using System.Threading.Tasks;
using ComicMaker.Blazor.Shared.Common.Commands;
using ComicMaker.Blazor.Shared.Common.Models;
using ComicMaker.Blazor.Shared.Common.Queries;
using ComicMaker.Blazor.Shared.Projects.Commands;
using ComicMaker.Blazor.Shared.Projects.Models;
using Optional;

namespace ComicMaker.Blazor.Client.Services.Interfaces
{
    public interface IProjectService
    {
        Task<Option<IList<ProjectSummary>, ErrorResult>> GetList(GetListQuery query);
        Task<Option<SuccessResult, ErrorResult>> Create(CreateProjectCommand command);
        Task<Option<SuccessResult, ErrorResult>> Update(UpdateProjectCommand command);
        Task<Option<SuccessResult, ErrorResult>> Delete(DeleteByIdCommand command);
    }
}
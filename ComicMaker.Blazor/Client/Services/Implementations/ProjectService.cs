using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ComicMaker.Blazor.Client.Extensions;
using ComicMaker.Blazor.Client.Services.Interfaces;
using ComicMaker.Blazor.Shared.Common.Commands;
using ComicMaker.Blazor.Shared.Common.Models;
using ComicMaker.Blazor.Shared.Common.Queries;
using ComicMaker.Blazor.Shared.Projects.Commands;
using ComicMaker.Blazor.Shared.Projects.Models;
using Optional;

namespace ComicMaker.Blazor.Client.Services.Implementations
{
    public class ProjectService : ServiceBase, IProjectService
    {
        public ProjectService(HttpClient httpClient) : base(httpClient)
        {
        }
        public async Task<Option<IList<ProjectSummary>, ErrorResult>> GetList(GetListQuery query)
        {
            return await HttpClient.GetJsonAsOptionAsync<IList<ProjectSummary>>($"api/project");
        }

        public async Task<Option<SuccessResult, ErrorResult>> Create(CreateProjectCommand command)
        {
            return await HttpClient.PostJsonAsOptionAsync($"api/project", command);
        }

        public async Task<Option<SuccessResult, ErrorResult>> Update(UpdateProjectCommand command)
        {
            return await HttpClient.PutJsonAsOptionAsync($"api/project/{command.Id}", command);
        }

        public async Task<Option<SuccessResult, ErrorResult>> Delete(DeleteByIdCommand command)
        {
            return await HttpClient.DeleteAsOptionAsync($"api/project/{command.Id}");
        }
    }
}
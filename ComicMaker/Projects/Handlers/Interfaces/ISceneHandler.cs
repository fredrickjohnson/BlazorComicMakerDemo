using System.Collections.Generic;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;
using ComicMaker.Projects.Commands;
using ComicMaker.Projects.Models;
using Optional;

namespace ComicMaker.Projects.Handlers.Interfaces
{
    public interface ISceneHandler
    {
        Option<IEnumerable<Scene>, ErrorResult> GetAllFor(GetListByParentIdQuery query);
        Option<SuccessResult, ErrorResult> Create(CreateSceneCommand command);
        Option<SuccessResult, ErrorResult> Update(UpdateSceneCommand command);
        Option<SuccessResult, ErrorResult> Delete(DeleteByIdCommand command);
    }
}
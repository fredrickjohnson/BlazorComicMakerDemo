﻿using System.Collections.Generic;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;
using ComicMaker.Projects.Commands;
using ComicMaker.Projects.Models;
using Optional;

namespace ComicMaker.Projects.Handlers.Interfaces
{
    public interface IProjectHandler
    {
        Option<IEnumerable<ProjectSummary>, ErrorResult> GetAllForAccount(GetListQuery query);
        Option<SuccessResult, ErrorResult> Create(CreateProjectCommand command);
        Option<SuccessResult, ErrorResult> Update(UpdateProjectCommand command);
        Option<SuccessResult, ErrorResult> Delete(DeleteByIdCommand command);
    }
}

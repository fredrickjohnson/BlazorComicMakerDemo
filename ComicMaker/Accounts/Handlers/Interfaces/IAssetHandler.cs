﻿using System.Collections.Generic;
using ComicMaker.Accounts.Models;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;
using Optional;

namespace ComicMaker.Accounts.Handlers.Interfaces
{
    public interface IAssetHandler
    {
        Option<IEnumerable<Asset>, ErrorResult> GetAllForAccount(GetListQuery query);
        Option<SuccessResult, ErrorResult> Delete(DeleteByIdCommand command);
    }
}
using System.Collections.Generic;
using ComicMaker.Accounts.Commands;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;
using ComicMaker.Projects.Models;
using Optional;

namespace ComicMaker.Accounts.Handlers.Interfaces
{
    public interface ICharacterHandler
    {
        Option<IEnumerable<Character>, ErrorResult> GetAllForAccount(GetListQuery query);
        Option<SuccessResult, ErrorResult> Create(CreateCharacterCommand command);
        Option<SuccessResult, ErrorResult> Update(UpdateCharacterCommand command);
        Option<SuccessResult, ErrorResult> Delete(DeleteByIdCommand command);
    }
}
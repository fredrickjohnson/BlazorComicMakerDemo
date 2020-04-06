using System;
using System.Collections.Generic;
using System.Text;
using ComicMaker.Accounts.Commands;
using ComicMaker.Common.Models;
using Microsoft.Azure.Documents;
using Optional;

namespace ComicMaker.Accounts.Handlers.Interfaces
{
    public interface IAccountHandler
    {
        Option<SuccessResult, ErrorResult> Create(CreateAccountCommand command);
        Option<SuccessResult, ErrorResult> AddUser(AddUserToAccountCommand command);
        Option<SuccessResult, ErrorResult> RemoveUser(RemoveUserFromAccountCommand command);
    }
}

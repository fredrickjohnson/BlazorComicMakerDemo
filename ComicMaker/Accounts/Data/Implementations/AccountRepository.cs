﻿using ComicMaker.Accounts.Data.Interfaces;
using ComicMaker.Accounts.Entities;
using ComicMaker.Common.Data;
using ComicMaker.Common.Services.Interfaces;

namespace ComicMaker.Accounts.Data.Implementations
{
    public class AccountRepository : RepositoryBase<AccountEntity>, IAccountRepository
    {
        public AccountRepository(IConnectionString connectionString) : base(connectionString, Common.Data.Table.Account)
        {
        }
    }
}

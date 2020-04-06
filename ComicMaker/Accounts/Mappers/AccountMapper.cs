using System;
using System.Collections.Generic;
using System.Text;
using ComicMaker.Accounts.Commands;
using ComicMaker.Accounts.Entities;

namespace ComicMaker.Accounts.Mappers
{
    public class AccountMapper
    {
        public AccountEntity Map(CreateAccountCommand source)
        {
            var destination = new AccountEntity
            {
                Name = source.Name
            };
            return destination;
        }
    }
}

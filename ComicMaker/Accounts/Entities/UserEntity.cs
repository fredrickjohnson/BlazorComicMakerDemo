﻿using ComicMaker.Common.Models;
using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Accounts.Entities
{
    public class UserEntity : TableEntity
    {
        public bool IsDeleted { get; set; } = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Auth0Id { get; set; }
        public string AccountsAsString { get; set; } = List.Empty();
    }
}
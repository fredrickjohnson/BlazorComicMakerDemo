using System.Collections.Generic;
using ComicMaker.Accounts.Models;
using ComicMaker.Common.Commands;

namespace ComicMaker.Accounts.Commands
{
    public class AddUserToAccountCommand : CommandQueryBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
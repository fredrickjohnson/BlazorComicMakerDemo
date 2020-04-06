using System;
using System.Text;
using ComicMaker.Common.Commands;

namespace ComicMaker.Accounts.Commands
{
    public class CreateAccountCommand : CommandQueryBase
    {
        public string Name { get; set; }
    }
}

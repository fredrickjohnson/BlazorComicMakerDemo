using ComicMaker.Common.Commands;

namespace ComicMaker.Accounts.Commands
{
    public class RemoveUserFromAccountCommand : CommandQueryBase
    {
        public string UserId { get; set; }
    }
}
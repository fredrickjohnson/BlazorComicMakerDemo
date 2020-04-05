using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Accounts.Entities
{
    public class AccountEntity : TableEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public string UsersAsString { get; set; }
    }
}
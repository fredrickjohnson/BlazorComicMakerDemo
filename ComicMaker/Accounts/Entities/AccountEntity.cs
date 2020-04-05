using Microsoft.Azure.Cosmos.Table;

namespace ComicMaker.Accounts.Entities
{
    public class AccountEntity : TableEntity
    {
        public string Name { get; set; }


    }
}
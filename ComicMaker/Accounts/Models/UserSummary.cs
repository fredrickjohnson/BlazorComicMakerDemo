using System.Collections.Generic;

namespace ComicMaker.Accounts.Models
{
    public class UserSummary
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<string> Claims { get; set; } = new List<string>();
    }
}
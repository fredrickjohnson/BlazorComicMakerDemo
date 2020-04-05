using System;
using System.Collections.Generic;

namespace ComicMaker.Common.Models
{
    public class Credentials
    {
        public string UserId { get; set; } = Guid.Empty.ToString();
        public string UserName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string AccountId { get; set; } = Guid.Empty.ToString();
        public IList<string> Claims { get; set; } = new List<string>();
    }
}
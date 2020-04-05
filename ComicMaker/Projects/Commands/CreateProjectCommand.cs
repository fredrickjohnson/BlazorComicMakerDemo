using System;
using System.Collections.Generic;
using System.Text;

namespace ComicMaker.Projects.Commands
{
    public class CreateProjectCommand
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

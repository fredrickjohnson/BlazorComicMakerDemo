using System;
using System.Collections.Generic;
using System.Text;
using ComicMaker.Common.Commands;

namespace ComicMaker.Projects.Commands
{
    public class CreateProjectCommand : CommandQueryBase
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

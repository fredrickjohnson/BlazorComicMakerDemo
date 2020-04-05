using System;
using System.Collections.Generic;
using System.Text;
using ComicMaker.Common.Commands;

namespace ComicMaker.Common.Queries
{
    public class GetAutoCompleteQuery : CommandQueryBase
    {
        public string Query { get; set; }
    }
}

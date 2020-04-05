using System;
using System.Collections.Generic;
using System.Text;
using ComicMaker.Common.Services.Interfaces;

namespace ComicMaker.Common.Services.Implementations
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}

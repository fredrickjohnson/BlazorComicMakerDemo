using System;

namespace ComicMaker.Common.Services.Implementations
{
    public static class IdFactory
    {
        public static string Create()
        {
            return Guid.NewGuid().ToString();
        }

        public static string Empty()
        {
            return Guid.Empty.ToString();
        }
    }
}
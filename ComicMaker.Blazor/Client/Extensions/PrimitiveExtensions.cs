using System;

namespace ComicMaker.Blazor.Client.Extensions
{
    public static class PrimitiveExtensions
    {
        public static void OnSuccess(this bool value, Action action)
        {
            if (value)
            {
                action?.Invoke();
            }
        }

        public static void OnFailed(this bool value, Action action)
        {
            if (!value)
            {
                action?.Invoke();
            }
        }
    }
}
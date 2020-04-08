using System;
using System.Net.Http;

namespace ComicMaker.Blazor.Client.Services.Implementations
{
    public abstract class ServiceBase
    {
        protected HttpClient HttpClient { get; }

        protected ServiceBase(HttpClient httpClient)
        {
            HttpClient = httpClient;
#if DEBUG
            HttpClient.BaseAddress = new Uri("http://localhost:7071");
#else
            HttpClient.BaseAddress = new Uri("http://localhost:7071");
#endif
        }
    }
}

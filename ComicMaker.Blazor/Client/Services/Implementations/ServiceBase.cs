using System;
using System.Net.Http;

namespace ComicMaker.Blazor.Client.Services.Implementations
{

    public abstract class ServiceBase
    {
        protected HttpClient Client { get; }

        protected ServiceBase()
        {

#if DEBUG
            Client = new System.Net.Http.HttpClient { BaseAddress = new Uri("https://localhost:44360") };
#else
            Client = new System.Net.Http.HttpClient {BaseAddress = new Uri("https://localhost:44360")};
#endif
        }
    }
}

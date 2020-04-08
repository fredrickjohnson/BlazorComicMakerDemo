using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ComicMaker.Blazor.Client.Models;
using ComicMaker.Blazor.Shared.Common.Models;
using Optional;

namespace ComicMaker.Blazor.Client.Extensions
{
    public static class HttpClientExtensions
    { 
        public static async Task<Option<T, ErrorResult>> GetJsonAsOptionAsync<T>(this HttpClient client, string path)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var text = await response.Content.ReadAsStringAsync();
                var model = JsonSerializer.Deserialize<T>(text, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                return Option.Some<T, ErrorResult>(model);
            }
            else
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        return Option.None<T, ErrorResult>(new ErrorResult());
                }
            }
            return Option.None<T, ErrorResult>(new ErrorResult());
        }



        public static async Task<Option<SuccessResult, ErrorResult>> PostJsonAsOptionAsync<T>(this HttpClient client, string path, T model)
        {
            //JsonContent.Create(model);
            //Console.WriteLine(content.);

            var response = await client.PostAsync(path,JsonContent.Create(model));
            if (response.IsSuccessStatusCode)
            {
                return Option.Some<SuccessResult, ErrorResult>(new SuccessResult());
            }
            else
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        return Option.None<SuccessResult, ErrorResult>(new ErrorResult());
                }
            }
            return Option.None<SuccessResult, ErrorResult>(new ErrorResult());
        }

        public static async Task<Option<SuccessResult, ErrorResult>> PutJsonAsOptionAsync<T>(this HttpClient client, string path, T model)
        {
            var response = await client.PutAsync(path,JsonContent.Create(model));
            if (response.IsSuccessStatusCode)
            {
                return Option.Some<SuccessResult, ErrorResult>(new SuccessResult());
            }
            else
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        return Option.None<SuccessResult, ErrorResult>(new ErrorResult());
                }
            }
            return Option.None<SuccessResult, ErrorResult>(new ErrorResult());
        }

        public static async Task<Option<SuccessResult, ErrorResult>> DeleteAsOptionAsync(this HttpClient client, string path)
        {
            var response = await client.DeleteAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return Option.Some<SuccessResult, ErrorResult>(new SuccessResult());
            }
            else
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        return Option.None<SuccessResult, ErrorResult>(new ErrorResult());
                }
            }
            return Option.None<SuccessResult, ErrorResult>(new ErrorResult());
        }
    }
}
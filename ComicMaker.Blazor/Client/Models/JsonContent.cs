using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ComicMaker.Blazor.Client.Models
{
    public static class JsonContent
    {
        public static StringContent Create<T>(T model)
        {
            return new StringContent(JsonSerializer.Serialize(model, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }), Encoding.UTF8, "application/json");
        }
    }
}
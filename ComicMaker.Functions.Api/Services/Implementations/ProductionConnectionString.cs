using ComicMaker.Common.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ComicMaker.Functions.Api.Services.Implementations
{
    public class ProductionConnectionString : IConnectionString
    {
        private readonly IConfiguration _configuration;

        public ProductionConnectionString(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Get()
        {
            return _configuration.GetConnectionString("AzureStorage");
        }
    }
}
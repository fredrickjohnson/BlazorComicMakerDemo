using System.IO;
using ComicMaker.Common.Services.Interfaces;
using Newtonsoft.Json;

namespace ComicMaker.Functions.Api.Services.Implementations
{
    public class DevelopmentConnectionString : IConnectionString
    {
        private readonly Model _settings;

        public DevelopmentConnectionString()
        {
            var path = Path.GetFullPath(@"..\..\..\..\appsettings.json");
            var text = File.ReadAllText(path);
            _settings = JsonConvert.DeserializeObject<Model>(text);
        }

        class Model
        {
            public Settings ConnectionStrings { get; set; } = new Settings();
        }

        class Settings
        {
            public string AzureStorage { get; set; }
        }

        public string Get()
        {
            return _settings.ConnectionStrings.AzureStorage;
        }
    }
}
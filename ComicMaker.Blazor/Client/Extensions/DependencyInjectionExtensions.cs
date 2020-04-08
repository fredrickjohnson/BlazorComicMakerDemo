using Blazored.Toast;
using ComicMaker.Blazor.Client.Services.Implementations;
using ComicMaker.Blazor.Client.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ComicMaker.Blazor.Client.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddModules(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddBlazoredToast();

            serviceCollection.AddScoped<IProjectService, ProjectService>();
            //serviceCollection.AddScoped<IAssetService, AssetService>();
            //serviceCollection.AddScoped<ICharacterService, CharacterService>();
            //serviceCollection.AddScoped<ISceneService, SceneService>();
            return serviceCollection;
        }
    }
}
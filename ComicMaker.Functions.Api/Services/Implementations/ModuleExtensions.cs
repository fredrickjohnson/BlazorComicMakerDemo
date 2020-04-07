using ComicMaker.Accounts.Data.Implementations;
using ComicMaker.Accounts.Data.Interfaces;
using ComicMaker.Accounts.Handlers.Implementations;
using ComicMaker.Accounts.Handlers.Interfaces;
using ComicMaker.Common.Services.Implementations;
using ComicMaker.Common.Services.Interfaces;
using ComicMaker.Projects.Data.Implementations;
using ComicMaker.Projects.Data.Interfaces;
using ComicMaker.Projects.Handlers.Implementations;
using ComicMaker.Projects.Handlers.Interfaces;
using ComicMaker.Projects.Services.Implementations;
using ComicMaker.Projects.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ComicMaker.Functions.Api.Services.Implementations
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddCommonModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDateTimeService, DateTimeService>();
#if DEBUG
            serviceCollection.AddSingleton<IConnectionString, DevelopmentConnectionString>();
#else
            serviceCollection.AddScoped<IConnectionString,ProductionConnectionString>();
#endif
            return serviceCollection;
        }

        public static IServiceCollection AddAccountsModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
            serviceCollection.AddScoped<IAccountQueryRepository, AccountQueryRepository>();
            serviceCollection.AddScoped<IAccountHandler, AccountHandler>();

            serviceCollection.AddScoped<IAssetRepository, AssetRepository>();
            serviceCollection.AddScoped<IAssetQueryRepository, AssetQueryRepository>();
            serviceCollection.AddScoped<IAssetHandler, AssetHandler>();

            serviceCollection.AddScoped<ICharacterRepository, CharacterRepository>();
            serviceCollection.AddScoped<ICharacterQueryRepository, CharacterQueryRepository>();
            serviceCollection.AddScoped<ICharacterHandler, CharacterHandler>();

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            //serviceCollection.AddScoped<IUserQueryRepository, UserQueryRepository>();
            //serviceCollection.AddScoped<IUserHandler, UserHandler>();
            return serviceCollection;
        }

        public static IServiceCollection AddProjectsModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProjectPartitionKeyGenerator, ProjectPartitionKeyGenerator>();

            serviceCollection.AddScoped<IProjectRepository, ProjectRepository>();
            serviceCollection.AddScoped<IProjectQueryRepository, ProjectQueryRepository>();
            serviceCollection.AddScoped<IProjectHandler, ProjectHandler>();

            serviceCollection.AddScoped<ISceneRepository, SceneRepository>();
            serviceCollection.AddScoped<ISceneQueryRepository, SceneQueryRepository>();
            serviceCollection.AddScoped<ISceneHandler, SceneHandler>();
            return serviceCollection;
        }
    }
}
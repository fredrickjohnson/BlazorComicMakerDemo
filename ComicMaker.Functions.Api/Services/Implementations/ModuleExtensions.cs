using ComicMaker.Common.Services.Implementations;
using ComicMaker.Common.Services.Interfaces;
using ComicMaker.Functions.Api.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ComicMaker.Functions.Api
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
            return serviceCollection;
        }

        public static IServiceCollection AddProjectsModule(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
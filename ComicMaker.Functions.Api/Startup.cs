using ComicMaker.Functions.Api.Services.Implementations;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ComicMaker.Functions.Api.Startup))]
namespace ComicMaker.Functions.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddHttpClient();

            /*
            builder.Services.AddSingleton((s) => {
                return new MyService();
            });

            builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();*/


            builder.Services.AddCommonModule();
            builder.Services.AddAccountsModule();
            builder.Services.AddProjectsModule();
        }
    }
}
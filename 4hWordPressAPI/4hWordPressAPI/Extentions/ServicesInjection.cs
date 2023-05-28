using _4HWordPress.Core.Infrastructure;
using _4HWordPress.Core.IRepositories;
using _4HWordPress.Core.IServices;
using Serilog;
using _4hWordPressAPI.Application.Services;
using _4HWordPress.Data.Repositories;

namespace _4hWordPressAPI.Extentions
{
    public static class ServicesInjection
    {
        /// <summary>
        /// Adds the services injection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="HostingEnvironment">The hosting environment.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddServicesInjection(this IServiceCollection services,
                                                                   IWebHostEnvironment HostingEnvironment,
                                                                   IConfiguration configuration)
        {
            ////Configure logger
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(configuration)
            //    .CreateLogger();
            //services.AddSingleton(Log.Logger);
            //services.AddSingleton(HostingEnvironment);
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddTransient<IConfigurationManager, _4HWordPress.Api.Infrastructure.ConfigurationManager>();
            //services.AddTransient<IConnectionFactory, ConnectionFactory>();

            //#region Services

            //services.AddTransient<IPublishedActivityService, PublishedActivityService>();
            //#endregion Services

            //#region Repositories

            //services.AddTransient<IPublishedActivityRepository, PublishedActivityRepository>();
            //#endregion Repositories

            return services;
        }
    }
}

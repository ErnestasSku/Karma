
using DataBase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KarmaWebApi
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabaseContext(this IServiceCollection services)
        {
            services.AddScoped<IDataBaseContext, DataBaseContext>();
        }
    }
}
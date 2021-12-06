
using DataBase.Services;
using Database.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;

namespace KarmaWebApi
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabaseContext(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseContext, DatabaseContext>();
            //services.AddScoped<IRepositoriesWrapper, RepositoriesWrapper>();
        }
    }
}
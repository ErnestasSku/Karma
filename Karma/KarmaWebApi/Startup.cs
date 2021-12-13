using Autofac;
using Serilog;
using DataBase.Services;
using KarmaWebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Database.Repositories;
using Database.Interfaces;
using KarmaWebApi.Interceptors;
using Autofac.Extras.DynamicProxy;
using Repository.Repositories;

namespace KarmaWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.txt")
                .CreateLogger();

            services.ConfigureDatabaseContext();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KarmaWebApi", Version = "v1" });
            });

            services.AddDbContext<DatabaseContext>();
        }

        public void ConfigureCOntainer(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoriesWrapper>().As<IRepositoriesWrapper>().
                EnableInterfaceInterceptors().InterceptedBy(typeof(LoggingInterceptor))
                .InstancePerDependency();
            
            builder.RegisterType<ItemRepository>().EnableClassInterceptors().InterceptedBy(typeof(LoggingInterceptor)).InstancePerDependency();
            builder.RegisterType<UserRepository>().EnableClassInterceptors().InterceptedBy(typeof(LoggingInterceptor)).InstancePerDependency();


            builder.RegisterType<ItemService>().EnableClassInterceptors().InterceptedBy(typeof(LoggingInterceptor)).InstancePerDependency();
            builder.RegisterType<UserService>().EnableClassInterceptors().InterceptedBy(typeof(LoggingInterceptor)).InstancePerDependency();

            builder.Register(x => Log.Logger).SingleInstance();
            builder.RegisterType<LoggingInterceptor>().SingleInstance();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KarmaWebApi v1"));
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

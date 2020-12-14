using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TruckTest.Domain.Interfaces.Repositories;
using TruckTest.Domain.Interfaces.Services;
using TruckTest.Infrastructure.Repository;
using TruckTest.Infrastructure.Service;

namespace TruckTest.WebApi.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            var ver = typeof(Startup).Assembly.GetName().Version.ToString();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                     new OpenApiInfo
                     {
                         Title = "Truck Test API",
                         Version = "v1",
                         Description = "Build: " + ver,
                         Contact = new OpenApiContact
                         {
                             Name = "TruckTest",
                         }
                     });
            }); 
        }

        public static void AddScopedClasses(this IServiceCollection services)
        {
            services.AddScoped<ITruckService, TruckService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
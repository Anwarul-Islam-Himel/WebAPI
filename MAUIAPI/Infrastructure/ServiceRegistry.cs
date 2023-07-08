using MauiAPI.Implementations;
using MauiAPI.Interfaces;
using MauiAPI.Mapping;
using Microsoft.EntityFrameworkCore;
using Service.AppDb;

namespace MauiAPI.Infrastructure
{
    public static class ServiceRegistry
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Db_Connection"));
            });

            services.AddTransient<IItemService, ItemService>();
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", policy =>
                  {
                      policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
                  });
            });

            return services;
        }
    }
}

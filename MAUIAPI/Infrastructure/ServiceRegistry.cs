using MauiAPI.Mapping;
using Microsoft.EntityFrameworkCore;
using Service.AppDb;
using Service.Implementations;
using Service.Interfaces;

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

            services.AddTransient<IIncomeService, IncomeService>();
            services.AddTransient<IExpenditureService, ExpenditureService>();
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

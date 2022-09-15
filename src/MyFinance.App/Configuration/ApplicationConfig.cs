using Microsoft.EntityFrameworkCore;
using MyFinance.Data.Context;

namespace MyFinance.App.Configuration
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MeuDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));



            return services;
        }
    }
}

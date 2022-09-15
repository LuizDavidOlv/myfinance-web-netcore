using MyFinance.App.Services;
using MyFinance.Business.Interfaces;
using MyFinance.Data.Context;
using MyFinance.Data.Repository;

namespace MyFinance.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IAccountPlanRepository, AccountPlanRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionReportRepository, TransactionReportRepository>();

            services.AddScoped<IAccountPlanService, AccountPlanService>();
            services.AddScoped<ITransactionService, TransactionService>();

            //services.AddScoped<IAccountPlanRepository, AccountPlanRepository>();
            //services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}

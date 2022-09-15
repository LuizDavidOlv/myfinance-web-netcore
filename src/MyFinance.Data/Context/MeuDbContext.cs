using Microsoft.EntityFrameworkCore;
using MyFinance.Business.Models;

namespace MyFinance.Data.Context
{
    public class MeuDbContext: DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options) { }  //é repassado para classe base options

        //Lembrar de adicionar as referências em Dependencies 
        public DbSet<AccountPlanModel> AccountPlans { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) //Método será chamado durante a criação deste modelo lá no banco
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;


            base.OnModelCreating(modelBuilder);
        }
    }
}

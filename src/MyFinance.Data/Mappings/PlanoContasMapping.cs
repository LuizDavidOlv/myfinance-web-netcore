//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using MyFinance.Business.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyFinance.Data.Mappings
//{
//    internal class PlanoContasMapping : IEntityTypeConfiguration<AccountPlanModel>
//    {
//        public void Configure(EntityTypeBuilder<AccountPlanModel> builder)
//        {
//            builder.HasKey(p => p.Id);

//            builder.Property(p => p.Description)
//                .IsRequired()
//                .HasColumnType("varchar(50)");

//            builder.Property(p => p.Type)
//                .IsRequired()
//                .HasColumnType("char(1)");

//            builder.ToTable("PlanoContas");
//        }
//    }
//}

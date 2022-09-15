//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using MyFinance.Business.Models;

//namespace MyFinance.Data.Mappings
//{
//    internal class TransacaoMapping : IEntityTypeConfiguration<TransactionModel>
//    {
//        public void Configure(EntityTypeBuilder<TransactionModel> builder)
//        {
//            builder.HasKey(p => p.Id);

//            builder.Property(p => p.PlanoContasId)
//                .IsRequired()
//                .HasColumnType("int");

//            builder.Property(p => p.Data)
//                .IsRequired()
//                .HasColumnType("datetime");

//            builder.Property(p => p.Valor)
//                 .IsRequired()
//                 .HasColumnType("Decimal(18,2)");

//            builder.Property(p => p.Tipo)
//                .IsRequired()
//                .HasColumnType("char(1))");

//            builder.Property(p => p.Historico)
//               .IsRequired()
//               .HasColumnType("text");



//            builder.ToTable("Transacoes");
//        }
//    }
//}


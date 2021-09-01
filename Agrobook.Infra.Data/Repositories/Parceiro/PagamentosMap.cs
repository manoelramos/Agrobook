namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PagamentosMap : EntityTypeConfiguration<Pagamentos>
    {
        protected override void Configure(EntityTypeBuilder<Pagamentos> builder)
        {
            builder.Property(c => c.Observacao)
               .HasColumnType("varchar(400)")
               .IsRequired();

            builder.HasOne(c => c.Associados)
              .WithMany(c => c.Pagamentos)
              .HasForeignKey(c => c.AssociadoId);

            builder.HasOne(c => c.Despesa)
                .WithMany(c => c.Pagamentos)
                 .HasForeignKey(b => b.DespesaId);
        }
    }
}

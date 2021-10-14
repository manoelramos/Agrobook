namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ParcelasMap : EntityTypeConfiguration<Parcelas>
    {
        protected override void Configure(EntityTypeBuilder<Parcelas> builder)
        {
            builder.Property(c => c.Observacao)
               .HasColumnType("varchar(400)")
               .IsRequired();

            builder.HasOne(c => c.Despesa)
                .WithMany(c => c.Parcelas)
                 .HasForeignKey(b => b.DespesaId);

            builder.HasOne(c => c.Moeda)
                .WithMany(c => c.Parcelas)
                 .HasForeignKey(b => b.IdMoedaParcela)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

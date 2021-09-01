namespace Agrobook.Infra.Data.Repositories.Despesas
{
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Agrobook.Domain.Models.Caixa;
    using Microsoft.EntityFrameworkCore;

    internal class DespesasMap : EntityTypeConfiguration<Despesas>
    {
        protected override void Configure(EntityTypeBuilder<Despesas> builder)
        {            

            builder.Property(c => c.Observacao)
              .HasColumnType("varchar(400)");

            builder.HasOne(c => c.Safra)
                .WithMany(c => c.Despesas)
                 .HasForeignKey(b => b.SafraId);

            builder.HasOne(c => c.Patrimonio)
                .WithMany(c => c.Despesas)
                 .HasForeignKey(b => b.PatrimonioId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.CategoriaDespesa)
                .WithMany(c => c.Despesas)
                 .HasForeignKey(b => b.CategoriaDespesaId);

            builder.HasOne(c => c.Moeda)
                .WithMany(c => c.Despesas)
                 .HasForeignKey(b => b.MoedaId);

        }
    }
}

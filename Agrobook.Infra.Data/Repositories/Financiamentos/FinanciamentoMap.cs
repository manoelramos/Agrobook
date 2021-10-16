namespace Agrobook.Infra.Data.Repositories.Financiamentos
{
    using Agrobook.Domain.Models;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class FinanciamentoMap : EntityTypeConfiguration<Financiamentos>
    {
        protected override void Configure(EntityTypeBuilder<Financiamentos> builder)
        {

            builder.HasOne(c => c.Moeda)
               .WithMany(c => c.Financiamentos)
                .HasForeignKey(b => b.IdMoedaParcela)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Parcelas)
              .WithOne(c => c.Financiamentos)
               .HasForeignKey(b => b.FinanciamentoId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Patrimonio)
              .WithMany(c => c.Financiamentos)
               .HasForeignKey(b => b.PatrimonioId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Credor)
             .WithMany(c => c.Financiamentos)
              .HasForeignKey(b => b.CredorId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

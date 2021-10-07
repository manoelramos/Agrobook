namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class LancamentosContabeisMap : EntityTypeConfiguration<LancamentosContabeis>
    {
        protected override void Configure(EntityTypeBuilder<LancamentosContabeis> builder)
        {
            builder.HasOne(c => c.Cultura)
              .WithMany(c => c.LancamentosContabeis)
              .HasForeignKey(c => c.CulturaId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.TipoLancamento)
              .WithMany(c => c.LancamentosContabeis)
              .HasForeignKey(c => c.TipoLancamentoId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Pagamento)
              .WithMany(c => c.LancamentosContabeis)
              .HasForeignKey(c => c.PagamentoId);
        }
    }
}

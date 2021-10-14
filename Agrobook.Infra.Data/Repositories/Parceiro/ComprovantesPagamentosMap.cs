namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ComprovantesPagamentosMap : EntityTypeConfiguration<ComprovantesPagamentos>
    {
        protected override void Configure(EntityTypeBuilder<ComprovantesPagamentos> builder)
        {
            builder.HasOne(c => c.Parcelas)
                 .WithMany(c => c.ComprovantesPagamentos)
                  .HasForeignKey(b => b.ParcelasId);
        }
    }
}

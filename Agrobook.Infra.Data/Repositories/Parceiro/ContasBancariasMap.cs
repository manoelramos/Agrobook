namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ContasBancariasMap : EntityTypeConfiguration<DadosBancarios>
    {
        protected override void Configure(EntityTypeBuilder<DadosBancarios> builder)
        {
            builder.HasOne(c => c.Associado)
                 .WithMany(c => c.DadosBancarios)
                  .HasForeignKey(b => b.AssociadoId);
        }
    }
}

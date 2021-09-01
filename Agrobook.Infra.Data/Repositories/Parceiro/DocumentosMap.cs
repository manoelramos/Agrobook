namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class DocumentosMap : EntityTypeConfiguration<Documentos>
    {
        protected override void Configure(EntityTypeBuilder<Documentos> builder)
        {
            builder.HasOne(c => c.Associado)
                 .WithMany(c => c.Documentos)
                  .HasForeignKey(b => b.AssociadosId);
        }
    }
}

namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ContatosMap : EntityTypeConfiguration<Contatos>
    {
        protected override void Configure(EntityTypeBuilder<Contatos> builder)
        {
            builder.HasOne(c => c.Associado)
                 .WithMany(c => c.Contatos)
                  .HasForeignKey(b => b.AssociadoId);
                  //.OnDelete(DeleteBehavior.NoAction);
        }
    }
}

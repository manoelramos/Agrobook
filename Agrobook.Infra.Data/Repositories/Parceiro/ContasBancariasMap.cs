namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ContasBancariasMap : EntityTypeConfiguration<ContasBancarias>
    {
        protected override void Configure(EntityTypeBuilder<ContasBancarias> builder)
        {
            builder.HasOne(c => c.Associado)
                 .WithMany(c => c.ContasBancarias)
                  .HasForeignKey(b => b.AssociadoId);
            //.OnDelete(DeleteBehavior.NoAction);
        }
    }
}

namespace Agrobook.Infra.Data.Repositories.UnidadesMedidas
{
    using Agrobook.Domain.Models.Base;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UnidadesMedidaAgroMap : EntityTypeConfiguration<UnidadesMedidasAgro>
    {
        protected override void Configure(EntityTypeBuilder<UnidadesMedidasAgro> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.HasOne(c => c.UnidadesMedidas)
               .WithMany(c => c.UnidadesMedidaAgro)
                .HasForeignKey(b => b.UnidadesMedidasId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

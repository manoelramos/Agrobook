namespace Agrobook.Infra.Data.Repositories.UnidadesMedidas
{
    using Agrobook.Domain.Models.Base;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class UnidadesMedidaMap : EntityTypeConfiguration<UnidadesMedidas>
    {
        protected override void Configure(EntityTypeBuilder<UnidadesMedidas> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.HasOne(s => s.UnidadeMedidaCustom).
                WithMany(c => c.UnidadesMedidasCustom).
                HasForeignKey(x => x.UnidadeBaseId).
                OnDelete(DeleteBehavior.NoAction);
        }
    }
}

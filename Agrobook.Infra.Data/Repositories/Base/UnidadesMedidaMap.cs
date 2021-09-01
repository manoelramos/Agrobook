namespace Agrobook.Infra.Data.Repositories.Base
{
    using Agrobook.Domain.Models.Base;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class UnidadesMedidaMap : EntityTypeConfiguration<UnidadesMedida>
    {
        protected override void Configure(EntityTypeBuilder<UnidadesMedida> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(100)")
               .IsRequired();           
        }
    }
}

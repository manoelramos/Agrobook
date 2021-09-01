namespace Agrobook.Infra.Data.Repositories.Base
{
    using Agrobook.Domain.Models.Base;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UnidadesMedidaAgroMap : EntityTypeConfiguration<UnidadesMedidaAgro>
    {
        protected override void Configure(EntityTypeBuilder<UnidadesMedidaAgro> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.HasOne(c => c.UnidadesMedida)
               .WithMany(c => c.UnidadesMedidaAgro)
                .HasForeignKey(b => b.UnidadesMedidaId);
        }
    }
}

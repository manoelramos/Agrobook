namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class TipoLancamentoMap : EntityTypeConfiguration<TiposLancamentos>
    {
        protected override void Configure(EntityTypeBuilder<TiposLancamentos> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(100)")
               .IsRequired();
        }
    }
}

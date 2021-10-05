namespace Agrobook.Infra.Data.Repositories.Veiculo
{
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class ManutencoesMap : EntityTypeConfiguration<Manutencoes>
    {
        protected override void Configure(EntityTypeBuilder<Manutencoes> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.HasOne(c => c.Veiculo)
                .WithMany(c => c.Manutencoes)
                .HasForeignKey(c => c.VeiculoId);
        }
    }
}

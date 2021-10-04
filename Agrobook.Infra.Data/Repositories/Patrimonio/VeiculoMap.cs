namespace Agrobook.Infra.Data.Repositories.Patrimonio
{
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class VeiculoMap : EntityTypeConfiguration<Veiculos>
    {
        protected override void Configure(EntityTypeBuilder<Veiculos> builder)
        {
            builder.Property(c => c.Placa)
               .HasColumnType("varchar(8)")
               .IsRequired();

            builder.HasOne(c => c.Patrimonio)
                .WithOne(c => c.Veiculo)
                .HasForeignKey<Veiculos>(c => c.PatrimonioId);
        }
    }
}

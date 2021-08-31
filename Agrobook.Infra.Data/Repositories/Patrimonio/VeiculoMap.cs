namespace Agrobook.Infra.Data.Repositories.Patrimonio
{
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class VeiculoMap : EntityTypeConfiguration<Veiculo>
    {
        protected override void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.Property(c => c.Placa)
               .HasColumnType("varchar(8)")
               .IsRequired();
        }
    }
}

namespace Agrobook.Infra.Data.Repositories.Localidade
{
    using Agrobook.Domain.Models;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class EnderecoMap : EntityTypeConfiguration<Enderecos>
    {
        protected override void Configure(EntityTypeBuilder<Enderecos> builder)
        {
            builder.Property(c => c.Logradouro)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(c => c.Latitude)
              .HasColumnType("float(10,6)");

            builder.Property(c => c.Longitude)
              .HasColumnType("float(10,6)");        
        }
    }
}

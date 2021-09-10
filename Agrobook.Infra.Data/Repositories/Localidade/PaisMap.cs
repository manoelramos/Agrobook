namespace Agrobook.Infra.Data.Repositories.Localidade
{
    using Agrobook.Domain.Models.Base;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PaisMap : EntityTypeConfiguration<Paises>
    {
        protected override void Configure(EntityTypeBuilder<Paises> builder)
        {
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(p => p.Iso)
               .HasColumnType("varchar(2)")
               .IsRequired();

            builder.Property(p => p.Iso3)
               .HasColumnType("varchar(3)")
               .IsRequired();
            
            builder.HasMany(c => c.Estados)
                .WithOne(c => c.Pais)
                .HasForeignKey(c => c.PaisId);

            builder.HasMany(c => c.Enderecos)
                .WithOne(c => c.Pais)
                .HasForeignKey(c => c.PaisId);
        }
    }
}

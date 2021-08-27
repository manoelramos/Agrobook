namespace Agrobook.Infra.Data.Repositories.Localidade
{
    using Agrobook.Domain.Models.Base;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PaisMap : EntityTypeConfiguration<Pais>
    {
        protected override void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(200)")
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

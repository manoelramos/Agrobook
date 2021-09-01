namespace Agrobook.Infra.Data.Repositories.Localidade
{
    using Agrobook.Domain.Models.Base;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CidadeMap : EntityTypeConfiguration<Cidades>
    {
        protected override void Configure(EntityTypeBuilder<Cidades> builder)
        {
            builder.Property(c => c.Nome)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.HasOne(c => c.Estado)
                .WithMany(c => c.Cidades)
                .HasForeignKey(c => c.EstadoId);

            builder.HasMany(c => c.Enderecos)
                .WithOne(c => c.Cidade)
                .HasForeignKey(c => c.CidadeId);
        }
    }
}

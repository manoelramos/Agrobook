namespace Agrobook.Infra.Data.Repositories.Localidade
{
    using Agrobook.Domain.Models.Base;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class EstadoMap : EntityTypeConfiguration<Estados>
    {
        protected override void Configure(EntityTypeBuilder<Estados> builder)
        {
            builder.Property(c => c.Nome)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(c => c.Uf)
               .HasColumnType("varchar(2)")
               .IsRequired();

            builder.HasMany(c => c.Cidades)
                .WithOne(c => c.Estado)
                .HasForeignKey(c => c.EstadoId)
                .OnDelete(DeleteBehavior.NoAction);           
        }
    }
}

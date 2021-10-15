namespace Agrobook.Infra.Data.Repositories.Cultura
{
    using Agrobook.Domain.Models.Producao;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class CulturaMap : EntityTypeConfiguration<Culturas>
    {
        protected override void Configure(EntityTypeBuilder<Culturas> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.HasMany(c => c.Safras)
           .WithOne(c => c.Cultura)
            .HasForeignKey(b => b.CulturaId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

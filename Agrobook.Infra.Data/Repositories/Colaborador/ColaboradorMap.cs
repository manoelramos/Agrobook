namespace Agrobook.Infra.Data.Repositories.Colaborador
{
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Agrobook.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    internal class ColaboradorMap : EntityTypeConfiguration<Colaborador>
    {
        protected override void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.Property(c => c.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(200)")
                .IsRequired();
        }
    }
}

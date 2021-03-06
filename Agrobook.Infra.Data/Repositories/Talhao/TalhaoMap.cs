namespace Agrobook.Infra.Data.Repositories.Talhao
{
    using Agrobook.Domain.Models.Producao;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class TalhaoMap : EntityTypeConfiguration<Talhoes>
    {
        protected override void Configure(EntityTypeBuilder<Talhoes> builder)
        {
            builder.Property(c => c.Observacao)
                .HasColumnType("varchar(400)");

            builder.HasOne(c => c.Fazenda)
                .WithMany(c => c.Talhoes)
                 .HasForeignKey(b => b.FazendaId);
        }
    }
}

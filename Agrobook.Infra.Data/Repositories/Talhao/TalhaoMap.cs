namespace Agrobook.Infra.Data.Repositories.Talhao
{
    using Agrobook.Domain.Models.Producao;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class TalhaoMap : EntityTypeConfiguration<Talhao>
    {
        protected override void Configure(EntityTypeBuilder<Talhao> builder)
        {
            builder.HasOne(c => c.Fazenda)
                .WithMany(c => c.Talhoes)
                 .HasForeignKey(b => b.FazendaId);
        }
    }
}

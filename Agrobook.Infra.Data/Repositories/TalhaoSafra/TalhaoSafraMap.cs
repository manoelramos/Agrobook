namespace Agrobook.Infra.Data.Repositories.TalhaoSafra
{
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Agrobook.Domain.Models.Producao;

    internal class TalhaoSafraMap : EntityTypeConfiguration<TalhaoSafra>
    {
        protected override void Configure(EntityTypeBuilder<TalhaoSafra> builder)
        {
            builder.HasOne(c => c.Talhao)
                .WithMany(c => c.TalhaoSafras)
                 .HasForeignKey(b => b.TalhaId);

            builder.HasOne(c => c.Safra)
                .WithMany(c => c.TalhaoSafras)
                 .HasForeignKey(b => b.SafraId);
        }
    }    
}

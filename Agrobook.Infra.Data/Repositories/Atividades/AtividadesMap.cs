namespace Agrobook.Infra.Data.Repositories.Atividades
{
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Agrobook.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    internal class AtividadesMap : EntityTypeConfiguration<Atividades>
    {
        protected override void Configure(EntityTypeBuilder<Atividades> builder)
        {
            builder.Property(c => c.Descricao)
              .HasColumnType("varchar(200)");

            builder.HasOne(c => c.Safra)
                .WithMany(c => c.Atividades)
                 .HasForeignKey(b => b.SafraId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Talhao)
                .WithMany(c => c.Atividades)
                 .HasForeignKey(b => b.TalhaoId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Veiculo)
                .WithMany(c => c.Atividades)
                 .HasForeignKey(b => b.VeiculoId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Associado)
               .WithMany(c => c.Atividades)
                .HasForeignKey(b => b.AssociadoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

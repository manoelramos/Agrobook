namespace Agrobook.Infra.Data.Repositories.Imoveis
{
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ImoveisMap : EntityTypeConfiguration<Imoveis>
    {
        protected override void Configure(EntityTypeBuilder<Imoveis> builder)
        {
            builder.HasOne(c => c.Endereco)
                .WithMany(c => c.Imoveis)
                .HasForeignKey(c => c.EnderecoId);

            builder.HasOne(c => c.Patrimonio)
                .WithOne(c => c.Imovel)
                .HasForeignKey<Imoveis>(c => c.PatrimonioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Fazenda)
                .WithMany(c => c.Imoveis)
                .HasForeignKey(c => c.FazendaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Classe)
                .WithMany(c => c.Imoveis)
                .HasForeignKey(c => c.ClasseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.UnidadeMedidaArea)
                .WithMany(c => c.Imoveis)
                .HasForeignKey(nameof(Imoveis.UnidadeMedidaAreaId))
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(nameof(Imoveis.UnidadeMedidaCapcidade))
                .WithMany()
                .HasForeignKey(nameof(Imoveis.UnidadeMedidaCapacidadeId))
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

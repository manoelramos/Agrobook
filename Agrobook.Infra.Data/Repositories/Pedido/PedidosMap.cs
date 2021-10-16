namespace Agrobook.Infra.Data.Repositories.Pedido
{
    using Agrobook.Domain.Models.Pedido;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PedidosMap : EntityTypeConfiguration<Pedidos>
    {
        protected override void Configure(EntityTypeBuilder<Pedidos> builder)
        {
            builder.HasOne(c => c.UnidadeMedida)
                .WithMany(c => c.Pedidos)
                 .HasForeignKey(b => b.UnidadeMedidaId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Fazenda)
                .WithMany(c => c.Pedidos)
                 .HasForeignKey(b => b.FazendaId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Fornecedor)
                .WithMany(c => c.Pedidos)
                 .HasForeignKey(b => b.FornecedorId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Insumo)
                .WithMany(c => c.Pedidos)
                 .HasForeignKey(b => b.InsumoId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Parcelas)
                .WithOne(c => c.Pedido)
                 .HasForeignKey(b => b.PedidoId)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

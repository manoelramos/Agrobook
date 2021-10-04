namespace Agrobook.Infra.Data.Repositories.Patrimonio
{
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ImoveisMap : EntityTypeConfiguration<Imoveis>
    {
        protected override void Configure(EntityTypeBuilder<Imoveis> builder)
        {
            builder.Property(c => c.UnidadeMedidaArea)
               .HasColumnType("varchar(4)")
               .IsRequired();

            builder.Property(c => c.UnidadeMedidaCapacidade)
               .HasColumnType("varchar(4)")
               .IsRequired();

            builder.HasOne(c => c.Endereco)
                .WithMany(c => c.Imoveis)
                .HasForeignKey(c => c.EnderecoId);

            builder.HasOne(c => c.Patrimonio)
                .WithOne(c => c.Imovel)
                .HasForeignKey<Imoveis>(c => c.PatrimonioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

namespace Agrobook.Infra.Data.Repositories.Fazenda
{
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class FazendaMap : EntityTypeConfiguration<Fazendas>
    {
        protected override void Configure(EntityTypeBuilder<Fazendas> builder)
        {
            builder.Property(c => c.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(c => c.Descricao)
              .HasColumnType("varchar(200)");

            builder.HasOne(c => c.Endereco)
                .WithOne(c => c.Fazenda)
                 .HasForeignKey<Fazendas>(b => b.EnderecoId);

            builder.HasOne(c => c.Patrimonio)
                .WithOne(c => c.Fazenda)
                .HasForeignKey<Fazendas>(c => c.PatrimonioId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

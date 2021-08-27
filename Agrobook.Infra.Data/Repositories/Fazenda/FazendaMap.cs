namespace Agrobook.Infra.Data.Repositories.Fazenda
{
    using Agrobook.Infra.Data.TypeConfiguration;
    using Agrobook.Domain.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class FazendaMap : EntityTypeConfiguration<Fazenda>
    {
        protected override void Configure(EntityTypeBuilder<Fazenda> builder)
        {
            builder.Property(c => c.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(c => c.Descricao)
              .HasColumnType("varchar(200)");

            builder.HasOne(c => c.Endereco)
                .WithOne(c => c.Fazenda)
                 .HasForeignKey<Fazenda>(b => b.EnderecoId);          
        }
    }
}

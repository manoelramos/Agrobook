namespace Agrobook.Infra.Data.Repositories.Organizacao
{
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Agrobook.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    class OrganizacaoMap : EntityTypeConfiguration<Organizacoes>
    {
        protected override void Configure(EntityTypeBuilder<Organizacoes> builder)
        {
            builder.Property(c => c.NomeCompleto)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(c => c.NomeFantasia)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.HasOne(c => c.Endereco)
                .WithMany(c => c.Oraganizacoes)
                .HasForeignKey(c => c.EnderecoId);
        }
    }
}

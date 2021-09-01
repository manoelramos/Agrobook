namespace Agrobook.Infra.Data.Repositories.Patrimonio
{
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using Agrobook.Domain.Models.PatrimonioGroup;

    internal class PatrimonioMap : EntityTypeConfiguration<Patrimonios>
    {
        protected override void Configure(EntityTypeBuilder<Patrimonios> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.HasOne(c => c.Fazenda)
                .WithOne(c => c.Patrimonio)
                .HasForeignKey<Patrimonios>(c => c.FazendaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Veiculo)
               .WithOne(c => c.Patrimonio)
               .HasForeignKey<Patrimonios>(c => c.VeivuloId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Imovel)
              .WithOne(c => c.Patrimonio)
              .HasForeignKey<Patrimonios>(c => c.ImovelId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Organizacao)
                .WithMany(c => c.Patrimonios)
                .HasForeignKey(c => c.OrganizacaoId);
        }
    }
}

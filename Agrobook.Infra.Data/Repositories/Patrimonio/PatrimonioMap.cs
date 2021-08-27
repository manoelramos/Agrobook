namespace Agrobook.Infra.Data.Repositories.Patrimonio
{
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Agrobook.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    internal class PatrimonioMap : EntityTypeConfiguration<Patrimonio>
    {
        protected override void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.HasOne(c => c.Fazenda)
                .WithOne(c => c.Patrimonio)
                .HasForeignKey<Patrimonio>(c => c.FazendaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Organizacao)
                .WithMany(c => c.Patrimonios)
                .HasForeignKey(c => c.OrganizacaoId);
        }
    }
}

namespace Agrobook.Infra.Data.Repositories.Patrimonio
{
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class AnexosManutencaoMap : EntityTypeConfiguration<AnexosManutencao>
    {
        protected override void Configure(EntityTypeBuilder<AnexosManutencao> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(300)")
               .IsRequired();

            builder.HasOne(c => c.Manutencao)
                .WithMany(c => c.Anexos)
                .HasForeignKey(c => c.ManutencaoId);
        }
    }
}

namespace Agrobook.Infra.Data.Repositories.Veiculo
{
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class AnexosVeiculoMap : EntityTypeConfiguration<AnexosVeiculo>
    {
        protected override void Configure(EntityTypeBuilder<AnexosVeiculo> builder)
        {
            builder.Property(c => c.Descricao)
               .HasColumnType("varchar(300)")
               .IsRequired();

            builder.HasOne(c => c.Veiculo)
                .WithMany(c => c.Anexos)
                .HasForeignKey(c => c.VeiculoId);
        }
    }    
}

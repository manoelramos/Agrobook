namespace Agrobook.Infra.Data.Repositories.Patrimonio
{
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class DetalhesPatrimonioMap : EntityTypeConfiguration<DetalhesPatrimonio>
    {
        protected override void Configure(EntityTypeBuilder<DetalhesPatrimonio> builder)
        {
            builder.Property(c => c.Observacao)
               .HasColumnType("varchar(300)")
               .IsRequired();
            
            builder.HasOne(c => c.Patrimonio)
                .WithMany(c => c.Detalhes)
                .HasForeignKey(c => c.PatrimonioId);
        }
    }
}

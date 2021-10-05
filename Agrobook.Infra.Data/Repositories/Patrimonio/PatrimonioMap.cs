namespace Agrobook.Infra.Data.Repositories.Patrimonio
{
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PatrimonioMap : EntityTypeConfiguration<Patrimonios>
    {
        protected override void Configure(EntityTypeBuilder<Patrimonios> builder)
        {            
            builder.HasOne(c => c.Organizacao)
                .WithMany(c => c.Patrimonios)
                .HasForeignKey(c => c.OrganizacaoId);
        }
    }
}

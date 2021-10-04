namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PessoaFisicaMap : EntityTypeConfiguration<Fisicas>
    {
        protected override void Configure(EntityTypeBuilder<Fisicas> builder)
        {
            builder.HasOne(c => c.Pessoa)
               .WithOne(c => c.PessoaFisica)
               .HasForeignKey<Fisicas>(c => c.AssociadoId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PessoaFisicaMap : EntityTypeConfiguration<PessoasFisicas>
    {
        protected override void Configure(EntityTypeBuilder<PessoasFisicas> builder)
        {
            builder.HasOne(c => c.Associado)
               .WithOne(c => c.PessoaFisica)
               .HasForeignKey<PessoasFisicas>(c => c.AssociadoId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

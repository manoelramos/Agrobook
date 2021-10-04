namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PessoaJuridicaMap : EntityTypeConfiguration<Juridicas>
    {
        protected override void Configure(EntityTypeBuilder<Juridicas> builder)
        {
            builder.HasOne(c => c.Pessoa)
                .WithOne(c => c.PessoaJuridica)
                .HasForeignKey<Juridicas>(c => c.AssociadoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

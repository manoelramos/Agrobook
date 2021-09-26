namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class PessoaJuridicaMap : EntityTypeConfiguration<PessoasJuridicas>
    {
        protected override void Configure(EntityTypeBuilder<PessoasJuridicas> builder)
        {
            builder.HasOne(c => c.Associado)
                .WithOne(c => c.PessoaJuridica)
                .HasForeignKey<PessoasJuridicas>(c => c.AssociadoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

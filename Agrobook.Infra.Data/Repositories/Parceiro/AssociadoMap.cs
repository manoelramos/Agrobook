namespace Agrobook.Infra.Data.Repositories.Colaborador
{
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Agrobook.Domain.Models.Parceiro;
    using Microsoft.EntityFrameworkCore;

    internal class AssociadoMap : EntityTypeConfiguration<Associados>
    {
        protected override void Configure(EntityTypeBuilder<Associados> builder)
        {
            builder.Property(c => c.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.HasOne(c => c.Contratacao)
                .WithMany(c => c.Associados)
                .HasForeignKey(c => c.ContratacaoId);

            builder.HasOne(c => c.Endereco)
                .WithMany(c => c.Associados)
                .HasForeignKey(c => c.EnderecoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.PessoaFisica)
                .WithOne(c => c.Associado)
                .HasForeignKey<Associados>(c => c.PessoaFisicaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.PessoaJuridica)
               .WithOne(c => c.Associado)
               .HasForeignKey<Associados>(c => c.PessoaJuridicaId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

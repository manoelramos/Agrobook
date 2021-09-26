namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    internal class ContratacaoMap : EntityTypeConfiguration<Contratacoes>
    {
        protected override void Configure(EntityTypeBuilder<Contratacoes> builder)
        {
            builder.Property(c => c.Modelo)
                .HasConversion(
                    v => v,
                    v => (int)(ModeloContrato)Enum.Parse(typeof(ModeloContrato), v.ToString()))
                .IsUnicode(false);

            builder.HasOne(c => c.Organizacao)
                .WithMany(c => c.Contratacoes)
                .HasForeignKey(c => c.OrganizacaoId);

            builder.HasOne(c => c.Associado)
               .WithMany(c => c.Contratacoes)
               .HasForeignKey(c => c.AssociadoId);
        }
    }
}

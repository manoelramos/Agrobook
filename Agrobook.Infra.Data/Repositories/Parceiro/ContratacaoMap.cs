namespace Agrobook.Infra.Data.Repositories.Parceiro
{
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.TypeConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    internal class ContratacaoMap : EntityTypeConfiguration<Contratacao>
    {
        protected override void Configure(EntityTypeBuilder<Contratacao> builder)
        {
            builder.Property(c => c.Modelo)
                .HasConversion(
                    v => v,
                    v => (int)(ModeloContrato)Enum.Parse(typeof(ModeloContrato), v.ToString()))
                .IsUnicode(false);

            builder.HasOne(c => c.Organizacao)
                .WithMany(c => c.Contratacoes)
                .HasForeignKey(c => c.OrganizacaoId);
        }
    }
}

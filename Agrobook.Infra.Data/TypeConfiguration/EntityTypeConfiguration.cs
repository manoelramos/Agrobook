using Agrobook.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agrobook.Infra.Data.TypeConfiguration
{
    internal abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity<TEntity>
    {
        protected abstract void Configure(EntityTypeBuilder<TEntity> builder);

        void IEntityTypeConfiguration<TEntity>.Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name);
            builder.HasKey(t => t.Id);
            builder.Ignore(c => c.CascadeMode);

            Configure(builder);
        }
    }
}

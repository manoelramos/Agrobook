namespace Agrobook.Domain.Core.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        IDbContextTransaction CurrentTransaction { get; }

        DatabaseFacade Database { get; }

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

        Task<int> SaveAsync(CancellationToken cancellationToken = default);

        bool HasChanges();

        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}

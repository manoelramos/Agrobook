namespace Agrobook.Domain.Core.Data
{
    using Agrobook.Domain.Core.Models;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        IUnitOfWork UnitOfWork { get; }
        ValueTask<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken = default);

        ValueTask<List<TEntity>> GetAsync(CancellationToken cancellationToken = default);

        ValueTask<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        IQueryable<TEntity> GetQueryble(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        ValueTask<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        ValueTask<bool> ExistsAsync<TParameter>(Expression<Func<TParameter, bool>> predicate, CancellationToken cancellationToken = default) where TParameter : class;

        ValueTask<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        ValueTask<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        ValueTask DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        ValueTask DeleteAsync<TParameter>(TParameter entity, CancellationToken cancellationToken = default) where TParameter : Entity<TParameter>;

        ValueTask DeleteAsync(long id, CancellationToken cancellationToken = default);

        IQueryable<TEntity> Include();

        IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath);

        EntityEntry<TParameter> Entry<TParameter>(TParameter entity) where TParameter : class;

        Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql, CancellationToken cancellationToken = default);

        Task<int> ExecuteSqlRawAsync(string sql, CancellationToken cancellationToken = default);

        Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);

        Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default);

        DbConnection GetDbConnection();
    }
}

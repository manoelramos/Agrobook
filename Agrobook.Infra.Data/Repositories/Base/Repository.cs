namespace Agrobook.Infra.Data.Repositories.Base
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Infra.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Agrobook.Domain.Core.Data;

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected readonly ApplicationContext Context;
        protected readonly DbSet<TEntity> DbSet;
        private bool _disposed;

        protected Repository(ApplicationContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public ValueTask<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.AddedDate = DateTime.Now;
            var entityEntry = DbSet.Add(entity);
            return new ValueTask<TEntity>(entityEntry.Entity);
        }

        public ValueTask DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.Ativo = false;
            entity.ModifiedDate = DateTime.Now;
            return new ValueTask();
        }

        public ValueTask DeleteAsync<TParameter>(TParameter entity, CancellationToken cancellationToken = default) where TParameter : Entity<TParameter>
        {
            entity.Ativo = false;
            entity.ModifiedDate = DateTime.Now;
            return new ValueTask();
        }

        public async ValueTask DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var entity = DbSet.Find(id);
            entity.Ativo = false;
            entity.ModifiedDate = DateTime.Now;
            await SaveChangesAsync(cancellationToken);
        }

        public EntityEntry<TParameter> Entry<TParameter>(TParameter entity) where TParameter : class
        {
            return Context.Entry(entity);
        }

        public Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql, CancellationToken cancellationToken = default) =>
            Context.Database.ExecuteSqlInterpolatedAsync(sql, cancellationToken);

        public Task<int> ExecuteSqlRawAsync(string sql, CancellationToken cancellationToken = default) =>
           Context.Database.ExecuteSqlRawAsync(sql, cancellationToken);

        public Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters) =>
            Context.Database.ExecuteSqlRawAsync(sql, parameters);

        public Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default) =>
            Context.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);

        public async ValueTask<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.AnyAsync(predicate, cancellationToken);
        }

        public async ValueTask<bool> ExistsAsync<TParameter>(Expression<Func<TParameter, bool>> predicate, CancellationToken cancellationToken = default) where TParameter : class
        {
            return await Context.Set<TParameter>().AnyAsync(predicate, cancellationToken);
        }

        public async ValueTask<List<TEntity>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Include().ToListAsync(cancellationToken);
        }

        public async ValueTask<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Include().Where(predicate).ToListAsync(cancellationToken);
        }

        public async ValueTask<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await Include().SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public DbConnection GetDbConnection() =>
            Context.Database.GetDbConnection();

        public IQueryable<TEntity> Include()
        {
            return DbSet;
        }

        public IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        {
            return DbSet.Include(navigationPropertyPath);
        }

        public ValueTask<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.ModifiedDate = DateTime.Now;
            var entityEntry = DbSet.Update(entity);
            return new ValueTask<TEntity>(entityEntry.Entity);
        }

        protected virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
           Context.SaveChangesAsync(cancellationToken);

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                Context.Dispose();

            _disposed = true;
        }

        #endregion IDisposable
    }
}

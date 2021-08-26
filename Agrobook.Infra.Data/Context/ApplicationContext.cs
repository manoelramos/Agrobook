namespace Agrobook.Infra.Data.Context
{
    using Agrobook.Infra.Data.Repositories.Colaborador;
    using FluentValidation.Results;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.Configuration;
    using System.Threading;
    using System.Threading.Tasks;

    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        //DbSet<Colaborador> Colaborador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfiguration(new ColaboradorMap());

            //SetDecimalPoints(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }


        #region ContextTransaction

        public virtual IDbContextTransaction CurrentTransaction => Database.CurrentTransaction;

        public Task<int> SaveAsync(CancellationToken cancellationToken = default) =>
            SaveChangesAsync(cancellationToken);

        public bool HasChanges()
        {
            var hasChanges = ChangeTracker.HasChanges();
            return hasChanges;
        }

        public virtual async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (Database.CurrentTransaction != null)
                return Database.CurrentTransaction;

            return await Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (Database.CurrentTransaction != null)
                await Database.CurrentTransaction.CommitAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (Database.CurrentTransaction != null)
                await Database.CurrentTransaction.RollbackAsync(cancellationToken);
        }

        #endregion
    }
}

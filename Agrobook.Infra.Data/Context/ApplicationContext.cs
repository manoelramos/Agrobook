namespace Agrobook.Infra.Data.Context
{
    using Agrobook.Infra.Data.Repositories.Colaborador;
    using Agrobook.Infra.Data.Repositories.Fazenda;
    using Agrobook.Infra.Data.Repositories.Localidade;
    using Agrobook.Infra.Data.Repositories.Organizacao;
    using Agrobook.Infra.Data.Repositories.Patrimonio;
    using FluentValidation.Results;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.Configuration;
    using System.Linq;
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
            //modelBuilder.ApplyConfiguration(new ColaboradorMap());
            
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());


            modelBuilder.ApplyConfiguration(new OrganizacaoMap());
            modelBuilder.ApplyConfiguration(new PatrimonioMap());
            modelBuilder.ApplyConfiguration(new FazendaMap());
            
            
            SetDecimalPoints(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        private void SetDecimalPoints(ModelBuilder modelBuilder)
        {
            var properties = modelBuilder.Model.GetEntityTypes()
                                .SelectMany(t => t.GetProperties())
                                .Where(p => p.ClrType == typeof(decimal));

            foreach (var property in properties)
                property.SetColumnType("decimal(18, 6)");
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

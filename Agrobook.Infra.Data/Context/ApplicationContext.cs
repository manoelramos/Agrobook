namespace Agrobook.Infra.Data.Context
{
    using Agrobook.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.Configuration;
    using System.Linq;

    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        DbSet<Colaborador> Colaborador {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SetDecimalPoints(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        //private void SetDecimalPoints(ModelBuilder modelBuilder)
        //{
        //    var properties = modelBuilder.Model.GetEntityTypes()
        //                        .SelectMany(t => t.GetProperties())
        //                        .Where(p => p.ClrType == typeof(decimal));

        //    foreach (var property in properties)
        //        property.SetColumnType("decimal(18, 6)");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }

            //base.OnConfiguring(optionsBuilder);
        }

        private IDbContextTransaction _transaction;

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}

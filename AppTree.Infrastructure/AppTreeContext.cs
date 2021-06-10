using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using AppTree.Domain.AggregateModels.HostAggregate;

namespace AppTree.Infrastructure
{
    public class AppTreeContext : DbContext, IUnitOfWork
    { 

        public const string DefaultSchema = "dbo";
        public DbSet<Application> Applications { get; set; }
        public DbSet<Dependency> Dependencies { get; set; }

        public DbSet<ApplicationType> ApplicationTypes { get; set; }
        
        public DbSet<ApplicationEnvironment> ApplicationEnvironments { get; set; }
        
        public DbSet<Host> Hosts { get; set; }

        public AppTreeContext(DbContextOptions<AppTreeContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppTreeContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

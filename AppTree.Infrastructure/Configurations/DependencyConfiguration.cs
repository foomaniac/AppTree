using AppTree.Domain.AggregateModels.ApplicationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTree.Infrastructure.Configurations
{
    public class DependencyConfiguration : IEntityTypeConfiguration<Dependency>
    {
        public void Configure(EntityTypeBuilder<Dependency> builder)
        {
            builder.ToTable("Dependency", AppTreeContext.DefaultSchema);

            builder.HasKey(key => new { key.ParentApplicationId, key.ApplicationId });

            builder.HasOne(dep => dep.ParentApplication)
                .WithMany(app => app.Dependencies)
                .HasForeignKey(dep => dep.ParentApplicationId)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}

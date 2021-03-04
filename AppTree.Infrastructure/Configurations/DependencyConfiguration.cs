using AppTree.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTree.Infrastructure.Configurations
{
    public class DependencyConfiguration : IEntityTypeConfiguration<Dependency>
    {
        public void Configure(EntityTypeBuilder<Dependency> builder)
        {
            builder.ToTable("Dependency", AppTreeContext.DEFAULT_SCHEMA);

            builder
                .Property(app => app.ApplicationId)
                .HasColumnName(nameof(Dependency.ApplicationId))
                .HasColumnType("int")
                .IsRequired();

            builder
                    .Property(app => app.ParentApplicationId)
                    .HasColumnName(nameof(Dependency.ParentApplicationId))
                    .HasColumnType("int")
                    .IsRequired();

        }
    }
}

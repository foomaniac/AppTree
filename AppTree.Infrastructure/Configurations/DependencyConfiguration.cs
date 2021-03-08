using AppTree.Domain.AggregateModels.ApplicationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AppTree.Infrastructure.Configurations
{
    public class DependencyConfiguration : IEntityTypeConfiguration<Dependency>
    {
        public void Configure(EntityTypeBuilder<Dependency> builder)
        {
            builder.ToTable("Dependency", AppTreeContext.DEFAULT_SCHEMA);

            builder.HasKey(key => new { key.ParentApplicationId, key.ApplicationId });

            builder.HasOne(dep => dep.ParentApplication)
                .WithMany(app => app.Dependencies)
                .HasForeignKey(dep => dep.ParentApplicationId)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}

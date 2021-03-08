using AppTree.Domain.AggregateModels.ApplicationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTree.Infrastructure.Configurations
{
    public class DependencyConfiguration : IEntityTypeConfiguration<Dependency>
    {
        public void Configure(EntityTypeBuilder<Dependency> builder)
        {
            builder.HasOne(app => app.Application);
            builder.HasOne(app => app.ParentApplication);
            builder.HasNoKey();
        }
    }
}

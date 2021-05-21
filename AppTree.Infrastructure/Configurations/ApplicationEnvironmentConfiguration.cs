using AppTree.Domain.AggregateModels.ApplicationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AppTree.Infrastructure.Configurations
{
    public class ApplicationEnvironmentConfiguration : IEntityTypeConfiguration<ApplicationEnvironment>
    {
        public void Configure(EntityTypeBuilder<ApplicationEnvironment> builder)
        {
            builder.ToTable("ApplicationEnvironment", AppTreeContext.DefaultSchema);

            builder.HasKey(key => new { key.Id });

            builder.Property(app => app.HostId)
                .HasColumnName(nameof(ApplicationEnvironment.HostId))
                .HasColumnType("int").IsRequired();

            builder.HasOne(app => app.Host);

            builder.HasOne(appEnv => appEnv.ParentApplication)
                .WithMany(appEnv => appEnv.Environments)
                .HasForeignKey(appEnv =>appEnv.ApplicationId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

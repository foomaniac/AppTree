﻿using AppTree.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTree.Infrastructure.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Application", AppTreeContext.DEFAULT_SCHEMA);

            builder.HasKey(app => app.Id);

            builder
                .Property(app => app.Id)
                .HasColumnName(nameof(Application.Id))
                .HasColumnType("int")
                .IsRequired();

            builder.Property(app => app.Name)
                .HasColumnName(nameof(Application.Name))
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.Property(app => app.Summary)
                .HasColumnName(nameof(Application.Summary))
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(app => app.Repository)
                .HasColumnName(nameof(Application.Repository))
                .HasColumnType("nvarchar(256)")
                .IsRequired(false);
        }
    }
}
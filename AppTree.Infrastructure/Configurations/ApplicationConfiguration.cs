using AppTree.Domain.AggregateModels;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
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

            builder.HasMany(app => app.Dependencies).WithOne(app => app.ParentApplication).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(app => app.ApplicationType);

        }
    }
}

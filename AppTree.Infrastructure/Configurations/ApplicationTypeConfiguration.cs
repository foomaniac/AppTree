using AppTree.Domain.AggregateModels;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTree.Infrastructure.Configurations
{
    public class ApplicationTypeConfiguration : IEntityTypeConfiguration<ApplicationType>
    {
        public void Configure(EntityTypeBuilder<ApplicationType> builder)
        {
            builder.ToTable("ApplicationType", AppTreeContext.DefaultSchema);

            builder.HasKey(app => app.Id);

            builder
                .Property(app => app.Id)
                .HasColumnName(nameof(ApplicationType.Id))
                .HasColumnType("int")
                .IsRequired();

            builder.Property(app => app.Type)
                .HasColumnName(nameof(ApplicationType.Type))
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.HasData(new {Id = 1, Type = "Web Page"},
                new { Id = 2, Type = "API"});
        }
    }
}

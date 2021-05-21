using AppTree.Domain.AggregateModels;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Domain.AggregateModels.HostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppTree.Infrastructure.Configurations
{
    public class HostTypeConfiguration : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            builder.ToTable("Host", AppTreeContext.DefaultSchema);

            builder.HasKey(app => app.Id);

            builder
                .Property(app => app.Id)
                .HasColumnName(nameof(Host.Id))
                .HasColumnType("int")
                .IsRequired();

            builder.Property(app => app.HostName)
                .HasColumnName(nameof(Host.HostName))
                .HasColumnType("nvarchar(256)")
                .IsRequired();
            
            builder.Property(app => app.Domain)
                .HasColumnName(nameof(Host.Domain))
                .HasColumnType("nvarchar(256)");

            builder.Property(app => app.Location)
                .HasColumnName(nameof(Host.Location))
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(app => app.Summary)
                .HasColumnName(nameof(Host.Summary))
                .HasColumnType("nvarchar(max)");

            builder.HasData(new {Id = 1, HostName = "PRAPI02", Domain = "agepartnership.com", Location = "OnPrem" },
                new { Id = 2, HostName = "PRAPI11", Domain = "agepartnership.com", Location = "OnPrem" },
                new { Id = 3, HostName = "PRAPI21", Domain = "agepartnership.com", Location = "OnPrem" },
                new { Id = 4, HostName = "PRAPI04", Domain = "agepartnership.com", Location = "Azure" },
                new { Id = 5, HostName = "PRAPI05", Domain = "agepartnership.com", Location = "Azure" });
        }
    }
}

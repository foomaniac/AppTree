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

            builder.HasKey(host => host.Id);

            builder
                .Property(host => host.Id)
                .HasColumnName(nameof(Host.Id))
                .HasColumnType("int")
                .IsRequired();

            builder.Property(host => host.HostName)
                .HasColumnName(nameof(Host.HostName))
                .HasColumnType("nvarchar(256)")
                .IsRequired();
            
            builder.Property(host => host.Domain)
                .HasColumnName(nameof(Host.Domain))
                .HasColumnType("nvarchar(256)");

            builder.Property(host => host.Location)
                .HasColumnName(nameof(Host.Location))
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(host => host.Summary)
                .HasColumnName(nameof(Host.Summary))
                .HasColumnType("nvarchar(max)");

            builder.HasMany(host => host.Applications)
                .WithOne(appEnv => appEnv.Host)
                .HasForeignKey(appEnv => appEnv.HostId);

            builder.HasData(new {Id = 1, HostName = "PRAPI02", Domain = "agepartnership.com", Location = "OnPrem" },
                new { Id = 2, HostName = "PRAPI11", Domain = "agepartnership.com", Location = "OnPrem" },
                new { Id = 3, HostName = "PRAPI21", Domain = "agepartnership.com", Location = "OnPrem" },
                new { Id = 4, HostName = "PRAPI04", Domain = "agepartnership.com", Location = "Azure" },
                new { Id = 5, HostName = "PRAPI05", Domain = "agepartnership.com", Location = "Azure" });
        }
    }
}

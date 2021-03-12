﻿// <auto-generated />
using System;
using AppTree.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppTree.Infrastructure.Migrations
{
    [DbContext(typeof(AppTreeContext))]
    partial class AppTreeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppTree.Domain.AggregateModels.ApplicationAggregate.Application", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Repository")
                        .HasColumnName("Repository")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Summary")
                        .HasColumnName("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationTypeId");

                    b.ToTable("Application","dbo");
                });

            modelBuilder.Entity("AppTree.Domain.AggregateModels.ApplicationAggregate.ApplicationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("Type")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationType","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Web Page"
                        },
                        new
                        {
                            Id = 2,
                            Type = "API"
                        });
                });

            modelBuilder.Entity("AppTree.Domain.AggregateModels.ApplicationAggregate.Dependency", b =>
                {
                    b.Property<int>("ParentApplicationId")
                        .HasColumnType("int");

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.HasKey("ParentApplicationId", "ApplicationId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Dependency","dbo");
                });

            modelBuilder.Entity("AppTree.Domain.AggregateModels.ApplicationAggregate.Application", b =>
                {
                    b.HasOne("AppTree.Domain.AggregateModels.ApplicationAggregate.ApplicationType", "ApplicationType")
                        .WithMany()
                        .HasForeignKey("ApplicationTypeId");
                });

            modelBuilder.Entity("AppTree.Domain.AggregateModels.ApplicationAggregate.Dependency", b =>
                {
                    b.HasOne("AppTree.Domain.AggregateModels.ApplicationAggregate.Application", "Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppTree.Domain.AggregateModels.ApplicationAggregate.Application", "ParentApplication")
                        .WithMany("Dependencies")
                        .HasForeignKey("ParentApplicationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

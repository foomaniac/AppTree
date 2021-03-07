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
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppTree.Domain.Models.Application", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Name");

                    b.Property<string>("Repository")
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Repository");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Summary");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Application", "dbo");
                });

            modelBuilder.Entity("AppTree.Domain.Models.Application", b =>
                {
                    b.HasOne("AppTree.Domain.Models.Application", null)
                        .WithMany("Dependencies")
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("AppTree.Domain.Models.Application", b =>
                {
                    b.Navigation("Dependencies");
                });
#pragma warning restore 612, 618
        }
    }
}

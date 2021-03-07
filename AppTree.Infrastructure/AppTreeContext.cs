﻿using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppTree.Infrastructure
{
    public class AppTreeContext : DbContext, IUnitOfWork
    { 

        public const string DEFAULT_SCHEMA = "dbo";
        public DbSet<Application> Applications { get; set; }

        public AppTreeContext(DbContextOptions<AppTreeContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppTreeContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}

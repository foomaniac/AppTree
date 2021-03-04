using AppTree.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppTree.Infrastructure
{
    public class AppTreeContext : DbContext
    { 

        public const string DEFAULT_SCHEMA = "dbo";
        public DbSet<Application> Applications { get; set; }
        public DbSet<Dependency> Dependencies { get; set; }
    }
}

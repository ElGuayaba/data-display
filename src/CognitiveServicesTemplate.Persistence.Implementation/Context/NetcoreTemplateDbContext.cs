using System;
using Microsoft.EntityFrameworkCore;
using CognitiveServicesTemplate.Domain.Entity;
using CognitiveServicesTemplate.Persistence.Contract.Context;

namespace CognitiveServicesTemplate.Persistence.Implementation.Context
{
    public class CognitiveServicesTemplateDbContext : DbContext, ICognitiveServicesTemplateDbContext
    {
        public DbContext Instance => this;
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        
        protected CognitiveServicesTemplateDbContext()
        {
        }

        public CognitiveServicesTemplateDbContext(DbContextOptions<CognitiveServicesTemplateDbContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new ArgumentException("Database not properly configured");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CognitiveServicesTemplateDbContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
using System;
using DotNetBackendTemplate.Core.Entities;
using DotNetBackendTemplate.Core.Entities.Concrete;
using DotNetBackendTemplate.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DotNetBackendTemplate.DataAccess.Concrete.EntityFramework
{
	public class BaseDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1234;Database=DotNetBackendTemplate;");
        }

        public DbSet<SomeFeatureEntity> SomeFeatureEntities { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<AccountOperationClaim> AccountOperationClaims { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IEntity
                && (e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((IEntity)entityEntry.Entity).LastUpdatedTime = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IEntity)entityEntry.Entity).CreatedTime = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}


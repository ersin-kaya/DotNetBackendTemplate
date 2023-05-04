using System;
using DotNetBackendTemplate.Core.Entities.Concrete;
using DotNetBackendTemplate.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DotNetBackendTemplate.DataAccess.Concrete.EntityFramework
{
	public class BaseDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=DotNetBackendTemplate;User=SA;Password=y0sTP4sswd;Encrypt=False;");
        }

        public DbSet<SomeFeatureEntity> SomeFeatureEntities { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<AccountOperationClaim> AccountOperationClaims { get; set; }
    }
}


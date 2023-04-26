using System;
using DotNetBackendTemplate.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DotNetBackendTemplate.DataAccess.Concrete.EntityFramework
{
	public class DotNetBackendTemplateContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1234;Database=DotNetBackendTemplate;");
        }

        public DbSet<SomeFeatureEntity> SomeFeatureEntities { get; set; }
    }
}


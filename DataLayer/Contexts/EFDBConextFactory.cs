using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Contexts
{
    public class EFDBConextFactory
    {

        /// <summary>
        /// For migrations
        /// </summary>
        public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
        {
            public EFDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
                optionsBuilder.UseSqlServer("Server=DESKTOP-5PKGG7D;Database=KImplementor;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));
                
                return new EFDBContext(optionsBuilder.Options);
            }
        }
    }
}

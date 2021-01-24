using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.DAL.Factories
{
	internal class AppBaseContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
	{
#if DOCKER
        const string connectionString = "Server=db;Database=master;User=sa;Password=Your_password123;";
#else
        const string connectionString = "Data Source=sqlitedemo.db";
#endif
        public TContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

#if DOCKER
      
            optionsBuilder.UseSqlServer(connectionString);
#else
            optionsBuilder.UseSqlite(connectionString);
#endif

            var context = Activator.CreateInstance(typeof(TContext), new object[] { optionsBuilder.Options });

            return context as TContext;
        }
    }
}

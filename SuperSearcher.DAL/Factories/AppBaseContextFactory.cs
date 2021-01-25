#define MSSQL
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using System;

namespace SuperSearcher.DAL.Factories
{
	internal class AppBaseContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
	{
#if DOCKER || MSSQL
		//const string connectionString = "Server=db;Database=master;User=sa;Password=Your_password123;";
		private const string connectionString = "Data Source=SQL5101.site4now.net;Initial Catalog=DB_A116A4_ct;User Id=DB_A116A4_ct_admin;Password=Qwerty123!";
#else
        const string connectionString = "Data Source=sqlitedemo.db";
#endif
        public TContext CreateDbContext(string[] args)
        {
			DbContextOptionsBuilder<TContext> optionsBuilder = new DbContextOptionsBuilder<TContext>();

#if DOCKER || MSSQL
      
            optionsBuilder.UseSqlServer(connectionString);
#else
            optionsBuilder.UseSqlite(connectionString);
#endif

			object context = Activator.CreateInstance(typeof(TContext), new object[] { optionsBuilder.Options });

            return context as TContext;
        }
    }
}

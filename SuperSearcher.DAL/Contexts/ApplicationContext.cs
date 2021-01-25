
using Microsoft.EntityFrameworkCore;

using SuperSearcher.DAL.Entities;

namespace SuperSearcher.DAL.Contexts
{
	public class ApplicationContext: DbContext
	{
		private DbSet<SearchRequest> allRequests { get; set; }


		public ApplicationContext()
		{
			Database.EnsureCreated();
		}

		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SearchRequest>().HasKey(x=>x.Id);
			base.OnModelCreating(modelBuilder);
		}
	}
}

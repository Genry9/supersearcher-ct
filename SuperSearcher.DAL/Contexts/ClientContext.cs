using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using SuperSearcher.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSearcher.DAL.Contexts
{
	public class ClientContext : IdentityDbContext<User>
	{
		public ClientContext()
		{
			Database.EnsureCreated();
		}

		public ClientContext(DbContextOptions<ClientContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.HasDefaultSchema("client");

		}
	}
}

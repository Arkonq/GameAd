﻿using Microsoft.EntityFrameworkCore;

namespace GameAd
{
	public class Context : DbContext
	{
		private readonly string connectionString;
		public Context(string connectionString)
		{
			this.connectionString = connectionString;
			Database.EnsureCreated();
		}

		public DbSet<Game> Games { get; set; }
		public DbSet<Picture> Pictures { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
		}
	}
}

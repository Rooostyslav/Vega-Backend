using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Vega.DAL.Entity;

namespace Vega.DAL.EF
{
	public class VegaDbContext : DbContext
	{
		public DbSet<Make> Makes { get; set; }
		public DbSet<Model> Models { get; set; }
		public DbSet<Feature> Features { get; set; }

		public VegaDbContext(DbContextOptions<VegaDbContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			List<Make> makes = new List<Make>
			{
				new Make(){ Id = 1, Name = "BMV" },
				new Make() { Id = 2, Name = "VW" },
				new Make() { Id = 3, Name = "Ford" }
			};

			modelBuilder.Entity<Make>().HasData(makes);

			List<Model> models = new List<Model>
			{
				new Model(){ Id = 1, Name = "E90", MakeId = makes[0].Id },
				new Model(){ Id = 2, Name = "Caddy", MakeId = makes[1].Id },
				new Model(){ Id = 3, Name = "Mustang", MakeId = makes[2].Id }
			};

			List<Feature> features = new List<Feature>
			{
				new Feature() { Id = 1, Name = "ABS" },
				new Feature() { Id = 2, Name = "ESP" },
				new Feature() { Id = 3, Name = "Air Bag" }
			};

			modelBuilder.Entity<Model>().HasData(models);
			
			modelBuilder.Entity<Feature>().HasData(features);

			base.OnModelCreating(modelBuilder);
		}
	}
}

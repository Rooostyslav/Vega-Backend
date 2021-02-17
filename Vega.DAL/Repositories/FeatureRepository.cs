using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vega.DAL.EF;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.DAL.Repositories
{
	public class FeatureRepository : IRepository<Feature>
	{
		private readonly VegaDbContext vegaDbContext;
		private readonly DbSet<Feature> features;

		public FeatureRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
			features = vegaDbContext.Features;
		}

		public async Task<IEnumerable<Feature>> GetAllAsync()
		{
			return await features.ToListAsync();
		}

		public async Task<IEnumerable<Feature>> GetByQueryAsync(IQueryable<Feature> query)
		{
			return await query.ToListAsync();
		}

		public IQueryable<Feature> GetAll()
		{
			return features.AsNoTracking();
		}

		public async Task<Feature> GetAsync(int id)
		{
			return await features.FindAsync(id);
		}

		public async Task<IEnumerable<Feature>> FindAsync(Expression<Func<Feature, bool>> predicate)
		{
			return await features.Where(predicate).ToListAsync();
		}

		public IQueryable<Feature> FindBy(Expression<Func<Feature, bool>> predicate)
		{
			return features.Where(predicate);
		}

		public async Task CreateAsync(Feature item)
		{
			await features.AddAsync(item);
			await SaveAsync();
		}

		public async Task UpdateAsync(Feature item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
			await SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var feature = new Feature() { Id = id };
			features.Attach(feature);
			features.Remove(feature);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await vegaDbContext.SaveChangesAsync();
		}
	}
}

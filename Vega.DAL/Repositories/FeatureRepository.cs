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
		public readonly VegaDbContext vegaDbContext;

		public FeatureRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
		}

		public async Task<IEnumerable<Feature>> GetAllAsync()
		{
			return await vegaDbContext.Features.ToListAsync();
		}

		public async Task<Feature> GetAsync(int id)
		{
			return await vegaDbContext.Features.FindAsync(id);
		}

		public async Task<IEnumerable<Feature>> FindAsync(Expression<Func<Feature, bool>> predicate)
		{
			return await vegaDbContext.Features.Where(predicate).ToListAsync();
		}

		public async Task InsertAsync(Feature item)
		{
			await vegaDbContext.Features.AddAsync(item);
		}

		public void Update(Feature item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified; 
		}

		public void Delete(int id)
		{
			var feature = new Feature() { Id = id };
			vegaDbContext.Features.Attach(feature);
			vegaDbContext.Features.Remove(feature);
		}
	}
}

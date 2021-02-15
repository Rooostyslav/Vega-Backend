using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.DAL.EF;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.DAL.Repositories
{
	public class ModelRepository : IRepository<Model>
	{
		private readonly VegaDbContext vegaDbContext;

		public ModelRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
		}

		public async Task<IEnumerable<Model>> GetAllAsync()
		{
			return await vegaDbContext.Models.Include(m => m.Vehicles).ToListAsync();
		}

		public async Task<Model> GetAsync(int id)
		{
			return await vegaDbContext.Models.FindAsync(id);
		}

		public async Task<IEnumerable<Model>> FindAsync(Expression<Func<Model, bool>> predicate)
		{
			return await vegaDbContext.Models
				.Include(m => m.Vehicles)
				.Where(predicate)
				.ToListAsync();
		}

		public async Task InsertAsync(Model item)
		{
			await vegaDbContext.Models.AddAsync(item);
		}

		public void Update(Model item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			var model = new Model() { Id = id };
			vegaDbContext.Models.Attach(model);
			vegaDbContext.Models.Remove(model);
		}
	}
}

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
		private readonly DbSet<Model> models;

		public ModelRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
			models = vegaDbContext.Models;
		}

		public async Task<IEnumerable<Model>> GetAllAsync()
		{
			return await models.Include(m => m.Vehicles).ToListAsync();
		}

		public async Task<IEnumerable<Model>> GetByQueryAsync(IQueryable<Model> query)
		{
			return await query.ToListAsync();
		}

		public IQueryable<Model> GetAll()
		{
			return models.AsNoTracking();
		}

		public async Task<Model> GetAsync(int id)
		{
			return await models.FindAsync(id);
		}

		public async Task<IEnumerable<Model>> FindAsync(Expression<Func<Model, bool>> predicate)
		{
			return await models.Include(m => m.Vehicles)
				.Where(predicate)
				.ToListAsync();
		}

		public IQueryable<Model> FindBy(Expression<Func<Model, bool>> predicate)
		{
			return models.Where(predicate);
		}

		public async Task CreateAsync(Model item)
		{
			await models.AddAsync(item);
			await SaveAsync();
		}

		public async Task UpdateAsync(Model item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
			await SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var model = new Model() { Id = id };
			models.Attach(model);
			models.Remove(model);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await vegaDbContext.SaveChangesAsync();
		}
	}
}

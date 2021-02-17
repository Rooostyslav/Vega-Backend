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
	public class MakeRepository : IRepository<Make>
	{
		private readonly VegaDbContext vegaDbContext;
		private readonly DbSet<Make> makes;

		public MakeRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
			makes = vegaDbContext.Makes;
		}

		public async Task<IEnumerable<Make>> GetAllAsync()
		{
			return await makes.Include(m => m.Models).ToListAsync();
		}

		public async Task<IEnumerable<Make>> GetByQueryAsync(IQueryable<Make> query)
		{
			return await query.ToListAsync();
		}

		public IQueryable<Make> GetAll()
		{
			return makes.AsNoTracking();
		}

		public async Task<Make> GetAsync(int id)
		{
			return await makes.FindAsync(id);
		}

		public async Task<IEnumerable<Make>> FindAsync(Expression<Func<Make, bool>> predicate)
		{
			return await makes.Include(m => m.Models)
				.Where(predicate)
				.ToListAsync();
		}

		public IQueryable<Make> FindBy(Expression<Func<Make, bool>> predicate)
		{
			return makes.Where(predicate);
		}

		public async Task CreateAsync(Make item)
		{
			await makes.AddAsync(item);
			await SaveAsync();
		}

		public async Task UpdateAsync(Make item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
			await SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var make = new Make() { Id = id };
			makes.Attach(make);
			makes.Remove(make);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await vegaDbContext.SaveChangesAsync();
		}
	}
}

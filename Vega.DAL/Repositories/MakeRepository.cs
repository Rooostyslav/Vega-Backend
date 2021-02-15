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

		public MakeRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
		}

		public async Task<IEnumerable<Make>> GetAllAsync()
		{
			return await vegaDbContext.Makes.Include(m => m.Models).ToListAsync();
		}

		public async Task<Make> GetAsync(int id)
		{
			return await vegaDbContext.Makes.FindAsync(id);
		}

		public async Task<IEnumerable<Make>> FindAsync(Expression<Func<Make, bool>> predicate)
		{
			return await vegaDbContext.Makes
				.Include(m => m.Models)
				.Where(predicate)
				.ToListAsync();
		}

		public async Task InsertAsync(Make item)
		{
			await vegaDbContext.Makes.AddAsync(item);
		}

		public void Update(Make item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			var make = new Make() { Id = id };
			vegaDbContext.Makes.Attach(make);
			vegaDbContext.Makes.Remove(make);
		}
	}
}

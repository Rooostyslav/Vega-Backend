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
	public class VehicleRepository : IRepository<Vehicle>
	{
		private readonly VegaDbContext vegaDbContext;

		public VehicleRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
		}

		public async Task<IEnumerable<Vehicle>> GetAllAsync()
		{
			return await GetAllWithIncludes().ToListAsync();
		}

		public async Task<Vehicle> GetAsync(int id)
		{
			return await GetAllWithIncludes().FirstOrDefaultAsync(v => v.Id == id);
		}

		public async Task<IEnumerable<Vehicle>> FindAsync(Expression<Func<Vehicle, bool>> predicate)
		{
			return await GetAllWithIncludes().Where(predicate).ToListAsync();
		}

		public async Task InsertAsync(Vehicle item)
		{
			await vegaDbContext.Vehicles.AddAsync(item);
		}

		public void Update(Vehicle item)
		{
			var oldItem = GetAsync(item.Id).Result;
			oldItem.Features = item.Features;
			vegaDbContext.Entry(oldItem).CurrentValues.SetValues(item);
		}

		public void Delete(int id)
		{
			var vehicle = new Vehicle() { Id = id };
			vegaDbContext.Vehicles.Attach(vehicle);
			vegaDbContext.Vehicles.Remove(vehicle);
		}

		private IQueryable<Vehicle> GetAllWithIncludes()
		{
			return vegaDbContext.Vehicles
				.Include(v => v.Model)
				.ThenInclude(m => m.Make)
				.Include(v => v.Contact)
				.Include(v => v.Features);
		}
	}
}

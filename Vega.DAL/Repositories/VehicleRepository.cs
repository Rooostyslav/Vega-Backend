using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vega.DAL.EF;
using Vega.DAL.Entity;
using Vega.DAL.Extensions;
using Vega.DAL.Interfaces;

namespace Vega.DAL.Repositories
{
	public class VehicleRepository : IRepository<Vehicle>
	{
		private readonly VegaDbContext vegaDbContext;
		private readonly DbSet<Vehicle> vehicles;

		public VehicleRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
			vehicles = vegaDbContext.Vehicles;
		}

		public async Task<IEnumerable<Vehicle>> GetAllAsync()
		{
			return await vehicles.Includes().ToListAsync();
		}

		public async Task<IEnumerable<Vehicle>> GetByQueryAsync(IQueryable<Vehicle> query)
		{
			return await query.Includes().ToListAsync();
		}

		public IQueryable<Vehicle> GetAll()
		{
			return vehicles.AsNoTracking();
		}

		public async Task<Vehicle> GetAsync(int id)
		{
			return await vehicles.Includes().FirstOrDefaultAsync(v => v.Id == id);
		}

		public async Task<IEnumerable<Vehicle>> FindAsync(Expression<Func<Vehicle, bool>> predicate)
		{
			return await vehicles.Where(predicate).Includes().ToListAsync();
		}

		public IQueryable<Vehicle> FindBy(Expression<Func<Vehicle, bool>> predicate)
		{
			return vehicles.Includes().Where(predicate);
		}

		public async Task CreateAsync(Vehicle item)
		{
			await vehicles.AddAsync(item);
			await SaveAsync();
		}

		public async Task UpdateAsync(Vehicle item)
		{
			var oldItem = await GetAsync(item.Id);
			oldItem.Features = item.Features;
			vegaDbContext.Entry(oldItem).CurrentValues.SetValues(item);
			await SaveAsync();

		}

		public async Task DeleteAsync(int id)
		{
			var vehicle = new Vehicle() { Id = id };
			vehicles.Attach(vehicle);
			vehicles.Remove(vehicle);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await vegaDbContext.SaveChangesAsync();
		}
	}
}

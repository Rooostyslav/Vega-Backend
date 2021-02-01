using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public void Delete(int id)
		{
			var vehicle = Get(id);
			if (vehicle != null)
			{
				vegaDbContext.Vehicles.Remove(vehicle);
			}
		}

		public IEnumerable<Vehicle> Find(Func<Vehicle, bool> predicate)
		{
			return vegaDbContext.Vehicles.Include(v => v.Features).Where(predicate);
		}

		public Vehicle Get(int id)
		{
			return vegaDbContext.Vehicles.Find(id);
		}

		public IEnumerable<Vehicle> GetAll()
		{
			return vegaDbContext.Vehicles.Include(v => v.Features);
		}

		public void Insert(Vehicle item)
		{
			vegaDbContext.Vehicles.Add(item);
		}

		public void Update(Vehicle item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
		}
	}
}

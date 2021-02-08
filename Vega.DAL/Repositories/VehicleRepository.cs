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
			return GetAll().Where(predicate);
		}

		public Vehicle Get(int id)
		{
			return vegaDbContext.Vehicles
				.Include(v => v.Model.Make)
				.Include(v => v.Model)
				.Include(v => v.Contact)
				.Include(v => v.Features)
				.FirstOrDefault(v => v.Id == id);
		}

		public IEnumerable<Vehicle> GetAll()
		{
			return vegaDbContext.Vehicles
				.Include(v => v.Model.Make)
				.Include(v => v.Model)
				.Include(v => v.Contact)
				.Include(v => v.Features);
		}

		public void Insert(Vehicle item)
		{
			vegaDbContext.Vehicles.Add(item);
		}

		public void Update(Vehicle item)
		{
			var oldItem = Get(item.Id);
			oldItem.Features = item.Features;
			vegaDbContext.Entry(oldItem).CurrentValues.SetValues(item);
		}
	}
}

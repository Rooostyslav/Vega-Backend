using System;
using System.Collections.Generic;
using System.Linq;
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

		public void Delete(int id)
		{
			var model = Get(id);
			if (model != null)
			{
				vegaDbContext.Models.Remove(model);
			}
		}

		public IEnumerable<Model> Find(Func<Model, bool> predicate)
		{
			return vegaDbContext.Models.Include(m => m.Vehicles).Where(predicate);
		}

		public Model Get(int id)
		{
			return vegaDbContext.Models.Find(id);
		}

		public IEnumerable<Model> GetAll()
		{
			return vegaDbContext.Models.Include(m => m.Vehicles);
		}

		public void Insert(Model item)
		{
			vegaDbContext.Models.Add(item);
		}

		public void Update(Model item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
		}
	}
}

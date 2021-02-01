using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public void Delete(int id)
		{
			var feature = Get(id);
			if (feature != null)
			{
				vegaDbContext.Features.Remove(feature);
			}
		}

		public IEnumerable<Feature> Find(Func<Feature, bool> predicate)
		{
			return vegaDbContext.Features.Where(predicate);
		}

		public Feature Get(int id)
		{
			return vegaDbContext.Features.Find(id);
		}

		public IEnumerable<Feature> GetAll()
		{
			return vegaDbContext.Features;
		}

		public void Insert(Feature item)
		{
			vegaDbContext.Features.Add(item);
		}

		public void Update(Feature item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified; 
		}
	}
}

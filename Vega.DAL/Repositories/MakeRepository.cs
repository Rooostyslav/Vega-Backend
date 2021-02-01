using System;
using System.Collections.Generic;
using System.Linq;
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

		public IEnumerable<Make> GetAll()
		{
			return vegaDbContext.Makes.Include(m => m.Models);
		}

		public void Delete(int id)
		{
			var make = Get(id);
			if (make != null) 
			{
				vegaDbContext.Makes.Remove(make);
			}
		}

		public IEnumerable<Make> Find(Func<Make, bool> predicate)
		{
			return vegaDbContext.Makes.Include(m => m.Models).Where(predicate);
		}

		public Make Get(int id)
		{
			return vegaDbContext.Makes.Find(id);
		}

		public void Insert(Make item)
		{
			vegaDbContext.Makes.Add(item);
		}

		public void Update(Make item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
		}
	}
}

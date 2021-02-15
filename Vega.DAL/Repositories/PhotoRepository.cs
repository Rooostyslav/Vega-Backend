using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Vega.DAL.EF;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.DAL.Repositories
{
	public class PhotoRepository : IRepository<Photo>
	{
		private readonly VegaDbContext vegaDbContext;

		public PhotoRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
		}

		public void Delete(int id)
		{
			var photo = Get(id);
			if (photo != null)
			{
				vegaDbContext.Photos.Remove(photo);
			}
		}

		public IEnumerable<Photo> Find(Func<Photo, bool> predicate)
		{
			return vegaDbContext.Photos.Where(predicate);
		}

		public Photo Get(int id)
		{
			return vegaDbContext.Photos.Find(id);
		}

		public IEnumerable<Photo> GetAll()
		{
			return vegaDbContext.Photos;
		}

		public void Insert(Photo item)
		{
			vegaDbContext.Photos.Add(item);
		}

		public void Update(Photo item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
		}
	}
}

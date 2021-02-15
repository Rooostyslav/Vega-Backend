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
	public class PhotoRepository : IRepository<Photo>
	{
		private readonly VegaDbContext vegaDbContext;

		public PhotoRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
		}

		public async Task<IEnumerable<Photo>> GetAllAsync()
		{
			return await vegaDbContext.Photos.ToListAsync();
		}

		public async Task<Photo> GetAsync(int id)
		{
			return await vegaDbContext.Photos.FindAsync(id);
		}

		public async Task<IEnumerable<Photo>> FindAsync(Expression<Func<Photo, bool>> predicate)
		{
			return await vegaDbContext.Photos.Where(predicate).ToListAsync();
		}

		public async Task InsertAsync(Photo item)
		{
			await vegaDbContext.Photos.AddAsync(item);
		}

		public void Update(Photo item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			var photo = new Photo() { Id = id };
			vegaDbContext.Photos.Attach(photo);
			vegaDbContext.Photos.Remove(photo);
		}
	}
}

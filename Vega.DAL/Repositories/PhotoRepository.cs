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
		private readonly DbSet<Photo> photos;

		public PhotoRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
			photos = vegaDbContext.Photos;
		}

		public async Task<IEnumerable<Photo>> GetAllAsync()
		{
			return await photos.ToListAsync();
		}

		public async Task<IEnumerable<Photo>> GetByQueryAsync(IQueryable<Photo> query)
		{
			return await query.ToListAsync();
		}

		public IQueryable<Photo> GetAll()
		{
			return photos.AsNoTracking();
		}

		public async Task<Photo> GetAsync(int id)
		{
			return await photos.FindAsync(id);
		}

		public async Task<IEnumerable<Photo>> FindAsync(Expression<Func<Photo, bool>> predicate)
		{
			return await photos.Where(predicate).ToListAsync();
		}

		public IQueryable<Photo> FindBy(Expression<Func<Photo, bool>> predicate)
		{
			return photos.Where(predicate);
		}

		public async Task CreateAsync(Photo item)
		{
			await photos.AddAsync(item);
			await SaveAsync();
		}

		public async Task UpdateAsync(Photo item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
			await SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var photo = new Photo() { Id = id };
			photos.Attach(photo);
			photos.Remove(photo);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await vegaDbContext.SaveChangesAsync();
		}
	}
}

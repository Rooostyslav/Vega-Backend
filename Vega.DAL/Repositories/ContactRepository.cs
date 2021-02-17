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
	public class ContactRepository : IRepository<Contact>
	{
		private readonly VegaDbContext vegaDbContext;
		private readonly DbSet<Contact> contacts;

		public ContactRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
			contacts = vegaDbContext.Contacts;
		}

		public async Task<IEnumerable<Contact>> GetAllAsync()
		{
			return await contacts.Include(c => c.Vehicles).ToListAsync();
		}

		public async Task<IEnumerable<Contact>> GetByQueryAsync(IQueryable<Contact> query)
		{
			return await query.ToListAsync();
		}

		public IQueryable<Contact> GetAll()
		{
			return contacts.AsNoTracking();
		}

		public async Task<Contact> GetAsync(int id)
		{
			return await contacts.FindAsync(id);
		}

		public async Task<IEnumerable<Contact>> FindAsync(Expression<Func<Contact, bool>> predicate)
		{
			return await contacts.Include(c => c.Vehicles)
				.Where(predicate)
				.ToListAsync();
		}

		public IQueryable<Contact> FindBy(Expression<Func<Contact, bool>> predicate)
		{
			return contacts.Where(predicate);
		}

		public async Task CreateAsync(Contact item)
		{
			await contacts.AddAsync(item);
			await SaveAsync();
		}

		public async Task UpdateAsync(Contact item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
			await SaveAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var contact = new Contact() { Id = id };
			contacts.Attach(contact);
			contacts.Remove(contact);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await vegaDbContext.SaveChangesAsync();
		}
	}
}

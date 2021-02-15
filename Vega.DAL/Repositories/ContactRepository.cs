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

		public ContactRepository(VegaDbContext vegaDbContext)
		{
			this.vegaDbContext = vegaDbContext;
		}

		public async Task<Contact> GetAsync(int id)
		{
			return await vegaDbContext.Contacts.FindAsync(id);
		}

		public async Task<IEnumerable<Contact>> GetAllAsync()
		{
			return await vegaDbContext.Contacts.Include(c => c.Vehicles).ToListAsync();
		}

		public async Task<IEnumerable<Contact>> FindAsync(Expression<Func<Contact, bool>> predicate)
		{
			return await vegaDbContext.Contacts
				.Include(c => c.Vehicles)
				.Where(predicate)
				.ToListAsync();
		}

		public async Task InsertAsync(Contact item)
		{
			await vegaDbContext.Contacts.AddAsync(item);
		}

		public void Update(Contact item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			var contact = new Contact() { Id = id };
			vegaDbContext.Contacts.Attach(contact);
			vegaDbContext.Contacts.Remove(contact);
		}
	}
}

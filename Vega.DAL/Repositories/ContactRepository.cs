using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public void Delete(int id)
		{
			var contact = Get(id);
			if (contact != null)
			{
				vegaDbContext.Remove(contact);
			}
		}

		public IEnumerable<Contact> Find(Func<Contact, bool> predicate)
		{
			return vegaDbContext.Contacts.Include(c => c.Vehicles).Where(predicate);
		}

		public Contact Get(int id)
		{
			return vegaDbContext.Contacts.Find(id);
		}

		public IEnumerable<Contact> GetAll()
		{
			return vegaDbContext.Contacts.Include(c => c.Vehicles);
		}

		public void Insert(Contact item)
		{
			vegaDbContext.Contacts.Add(item);
		}

		public void Update(Contact item)
		{
			vegaDbContext.Entry(item).State = EntityState.Modified;
		}
	}
}

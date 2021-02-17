using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Vega.DAL.Interfaces
{
	public interface IRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();

		Task<IEnumerable<T>> GetByQueryAsync(IQueryable<T> query);

		IQueryable<T> GetAll();

		Task<T> GetAsync(int id);

		Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

		IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

		Task CreateAsync(T item);

		Task UpdateAsync(T item);

		Task DeleteAsync(int id);

		Task SaveAsync();
	}
}

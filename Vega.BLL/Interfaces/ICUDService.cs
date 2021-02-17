using System.Threading.Tasks;

namespace Vega.BLL.Interfaces
{
	public interface ICUDService<T> where T : class
	{
		Task CreateAsync(T item);

		Task UpdateAsync(int id, T item);

		Task DeleteAsync(int id);
	}
}

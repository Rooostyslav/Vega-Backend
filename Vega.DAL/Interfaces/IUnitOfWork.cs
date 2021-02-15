using System.Threading.Tasks;
using Vega.DAL.Entity;

namespace Vega.DAL.Interfaces
{
	public interface IUnitOfWork
	{
		IRepository<Make> Makes { get; }
		IRepository<Model> Models { get; }
		IRepository<Feature> Features { get; }
		IRepository<Vehicle> Vehicles { get; }
		IRepository<Contact> Contacts { get; }
		IRepository<Photo> Photos { get; }
		Task SaveAsync();
	}
}

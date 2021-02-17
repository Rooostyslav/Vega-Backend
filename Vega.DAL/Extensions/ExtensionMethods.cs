using Microsoft.EntityFrameworkCore;
using System.Linq;
using Vega.DAL.Entity;

namespace Vega.DAL.Extensions
{
	public static class ExtensionMethods
	{
		public static IQueryable<Vehicle> Includes(this IQueryable<Vehicle> vehiclesQuery)
		{
			return vehiclesQuery
				.Include(v => v.Model)
				.ThenInclude(m => m.Make)
				.Include(v => v.Contact)
				.Include(v => v.Features);
		}
	}
}

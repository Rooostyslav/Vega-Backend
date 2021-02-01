using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.BLL.DTO
{
	public class ContactDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }

		public virtual ICollection<VehicleDTO> Vehicles { get; set; }

		public ContactDTO()
		{
			Vehicles = new Collection<VehicleDTO>();
		}
	}
}

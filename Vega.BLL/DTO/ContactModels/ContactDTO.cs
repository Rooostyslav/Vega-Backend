using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vega.BLL.DTO.VehicleModels;

namespace Vega.BLL.DTO.ContactModels
{
	public class ContactDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }

		public ICollection<VehicleDTO> Vehicles { get; set; }

		public ContactDTO()
		{
			Vehicles = new Collection<VehicleDTO>();
		}
	}
}

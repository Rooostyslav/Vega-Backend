using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vega.BLL.DTO.ContactModels;

namespace Vega.BLL.DTO.VehicleModels
{
	public class ViewVehicleDTO
	{
		public int Id { get; set; }

		public KeyValuePair Made { get; set; }

		public KeyValuePair Model { get; set; }

		public ViewContactDTO Contact { get; set; }

		public bool IsRegistered { get; set; }

		public DateTime LastUpdate { get; set; }

		public virtual ICollection<KeyValuePair> Features { get; set; }

		public ViewVehicleDTO()
		{
			Features = new Collection<KeyValuePair>();
		}
	}
}

﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.BLL.DTO
{
	public class FeatureDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual ICollection<VehicleDTO> Vehicles { get; set; }

		public FeatureDTO()
		{
			Vehicles = new Collection<VehicleDTO>();
		}
	}
}

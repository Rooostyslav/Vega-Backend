﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.BLL.DTO
{
	public class VehicleDTO
	{
		public int Id { get; set; }

		public int ModelId { get; set; }

		public ModelDTO Model { get; set; }

		public int ContactId { get; set; }

		public ContactDTO Contact { get; set; }

		public bool IsRegistered { get; set; }

		public DateTime LastUpdate { get; set; }

		public virtual ICollection<FeatureDTO> Features { get; set; }

		public VehicleDTO()
		{
			Features = new Collection<FeatureDTO>();
		}
	}
}
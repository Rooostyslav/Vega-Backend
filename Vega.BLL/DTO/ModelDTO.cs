using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vega.BLL.DTO.VehicleModels;

namespace Vega.BLL.DTO
{
	public class ModelDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public MakeDTO Make { get; set; }

		public int MakeId { get; set; }

		public virtual ICollection<VehicleDTO> Vehicles { get; set; }

		public ModelDTO()
		{
			Vehicles = new Collection<VehicleDTO>();
		}
	}
}

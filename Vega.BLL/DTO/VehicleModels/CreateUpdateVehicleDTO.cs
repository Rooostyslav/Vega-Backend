using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.BLL.DTO.VehicleModels
{
	public class CreateUpdateVehicleDTO
	{
		[Required]
		public int ModelId { get; set; }

		[Required]
		public int ContactId { get; set; }

		[Required]
		public bool IsRegistered { get; set; }

		public virtual ICollection<int> Features { get; set; }

		public CreateUpdateVehicleDTO()
		{
			Features = new Collection<int>();
		}
	}
}

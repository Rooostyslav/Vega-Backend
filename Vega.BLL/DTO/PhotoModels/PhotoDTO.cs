using Vega.BLL.DTO.VehicleModels;

namespace Vega.BLL.DTO.PhotoModels
{
	public class PhotoDTO
	{
		public int Id { get; set; }

		public string FileName { get; set; }

		public int VehicleId { get; set; }

		public VehicleDTO Vehicle { get; set; }
	}
}

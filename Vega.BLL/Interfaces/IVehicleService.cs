using System.Collections.Generic;
using Vega.BLL.DTO;

namespace Vega.BLL.Interfaces
{
	public interface IVehicleService
	{
		void Insert(VehicleDTO vehicleDTO);
		void Update(VehicleDTO vehicleDTO);
		void Delete(int id);
		VehicleDTO GetVehicle(int id);
		IEnumerable<VehicleDTO> GetVehicles();
	}
}

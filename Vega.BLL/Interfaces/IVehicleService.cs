using System.Collections.Generic;
using Vega.BLL.BusinessModels;
using Vega.BLL.DTO.VehicleModels;

namespace Vega.BLL.Interfaces
{
	public interface IVehicleService
	{
		void Insert(CreateUpdateVehicleDTO createUpdateVehicleDTO);
		void Update(int id, CreateUpdateVehicleDTO createUpdateVehicleDTO);
		void Delete(int id);
		ViewVehicleDTO GetVehicle(int id);
		IEnumerable<ViewVehicleDTO> GetVehicles();
		QueryResult<ViewVehicleDTO> GetVehicles(VehicleFilter filter);
	}
}

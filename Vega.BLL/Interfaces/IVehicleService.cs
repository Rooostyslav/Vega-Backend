using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.BLL.BusinessModels;
using Vega.BLL.DTO.VehicleModels;

namespace Vega.BLL.Interfaces
{
	public interface IVehicleService : ICUDService<CreateUpdateVehicleDTO>
	{
		Task<ViewVehicleDTO> GetVehicleAsync(int id);

		Task<IEnumerable<ViewVehicleDTO>> GetVehiclesAsync();

		Task<QueryResult<ViewVehicleDTO>> GetVehiclesAsync(VehicleFilter filter);
	}
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.BLL.DTO.PhotoModels;

namespace Vega.BLL.Interfaces
{
	public interface IPhotoService : ICUDService<PhotoDTO>
	{
		Task<IEnumerable<PhotoDTO>> GetPhotosAsync(int vehicleId);

		Task<PhotoDTO> GetPhotoAsync(int vehicleId);
	}
}

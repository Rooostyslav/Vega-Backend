using System.Collections.Generic;
using Vega.BLL.DTO.PhotoModels;

namespace Vega.BLL.Interfaces
{
	public interface IPhotoService
	{
		void Insert(PhotoDTO photoDTO);
		void Delete(int id);
		PhotoDTO GetPhoto(int vehicleId);
		IEnumerable<PhotoDTO> GetPhotos(int vehicleId);
	}
}

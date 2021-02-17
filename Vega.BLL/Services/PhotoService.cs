using AutoMapper;
using System.Collections.Generic;
using Vega.BLL.DTO.PhotoModels;
using Vega.BLL.Interfaces;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.BLL.Services
{
	public class PhotoService : IPhotoService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public PhotoService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<PhotoDTO>> GetPhotosAsync(int vehicleId)
		{
			var photos = await unitOfWork.Photos.FindAsync(p => p.VehicleId == vehicleId);
			return mapper.Map<IEnumerable<PhotoDTO>>(photos);
		}

		public async Task<PhotoDTO> GetPhotoAsync(int vehicleId)
		{
			var photos = await unitOfWork.Photos.FindAsync(p => p.VehicleId == vehicleId);
			var photo = photos.FirstOrDefault();
			return mapper.Map<PhotoDTO>(photo);
		}

		public async Task CreateAsync(PhotoDTO photoDTO)
		{
			var photo = mapper.Map<Photo>(photoDTO);
			await unitOfWork.Photos.CreateAsync(photo);
		}

		public async Task UpdateAsync(int id, PhotoDTO item)
		{
			var photo = mapper.Map<Photo>(item);
			photo.Id = id;
			await unitOfWork.Photos.UpdateAsync(photo);
		}

		public async Task DeleteAsync(int id)
		{
			await unitOfWork.Photos.DeleteAsync(id);
		}
	}
}

using AutoMapper;
using System.Collections.Generic;
using Vega.BLL.DTO.PhotoModels;
using Vega.BLL.Interfaces;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;
using System.Linq;

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

		public void Insert(PhotoDTO photoDTO)
		{
			var photo = mapper.Map<Photo>(photoDTO);
			unitOfWork.Photos.Insert(photo);
			unitOfWork.Save();
		}

		public void Delete(int id)
		{
			var photo = unitOfWork.Photos.Get(id);
			if (photo != null)
			{
				unitOfWork.Photos.Delete(id);
			}
		}

		public PhotoDTO GetPhoto(int vehicleId)
		{
			var photo = unitOfWork.Photos.GetAll().FirstOrDefault(p => p.VehicleId == vehicleId);
			return mapper.Map<PhotoDTO>(photo);
		}

		public IEnumerable<PhotoDTO> GetPhotos(int vehicleId)
		{
			var photos = unitOfWork.Photos.Find(p => p.VehicleId == vehicleId);
			return mapper.Map<IEnumerable<PhotoDTO>>(photos);
		}
	}
}

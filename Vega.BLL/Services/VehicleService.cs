using AutoMapper;
using System.Collections.Generic;
using Vega.BLL.DTO;
using Vega.BLL.Interfaces;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.BLL.Services
{
	public class VehicleService : IVehicleService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public void Delete(int id)
		{
			unitOfWork.Vehicles.Delete(id);
			unitOfWork.Save();
		}

		public VehicleDTO GetVehicle(int id)
		{
			var vehicle = unitOfWork.Vehicles.Get(id);
			return mapper.Map<VehicleDTO>(vehicle);
		}

		public IEnumerable<VehicleDTO> GetVehicles()
		{
			var vehicles = unitOfWork.Vehicles.GetAll();
			return mapper.Map<IEnumerable<VehicleDTO>>(vehicles);
		}

		public void Insert(VehicleDTO vehicleDTO)
		{
			var vehicle = mapper.Map<Vehicle>(vehicleDTO);
			unitOfWork.Vehicles.Insert(vehicle);
		}

		public void Update(VehicleDTO vehicleDTO)
		{
			var vehicle = mapper.Map<Vehicle>(vehicleDTO);
			unitOfWork.Vehicles.Update(vehicle);
		}
	}
}

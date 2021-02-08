using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Vega.BLL.DTO.VehicleModels;
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

		public ViewVehicleDTO GetVehicle(int id)
		{
			var vehicle = unitOfWork.Vehicles.Get(id);
			return mapper.Map<ViewVehicleDTO>(vehicle);
		}

		public IEnumerable<ViewVehicleDTO> GetVehicles()
		{
			var vehicles = unitOfWork.Vehicles.GetAll();
			return mapper.Map<IEnumerable<ViewVehicleDTO>>(vehicles);
		}

		public void Insert(CreateUpdateVehicleDTO createUpdateVehicleDTO)
		{
			var vehicle = CreateUpdateVehicleToVehicle(createUpdateVehicleDTO);
			unitOfWork.Vehicles.Insert(vehicle);
			unitOfWork.Save();
		}

		public void Update(int id, CreateUpdateVehicleDTO createUpdateVehicleDTO)
		{
			var vehicle = CreateUpdateVehicleToVehicle(createUpdateVehicleDTO);
			vehicle.Id = id;
			unitOfWork.Vehicles.Update(vehicle);
			unitOfWork.Save();
		}

		private Vehicle CreateUpdateVehicleToVehicle(CreateUpdateVehicleDTO createUpdateVehicleDTO)
		{
			var vehicle = mapper.Map<Vehicle>(createUpdateVehicleDTO);
			vehicle.Features = createUpdateVehicleDTO.Features
				.Select(f => unitOfWork.Features.Get(f))
				.ToList();

			vehicle.LastUpdate = DateTime.Now;
			return vehicle;
		}
	}
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Vega.BLL.BusinessModels;
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

		public QueryResult<ViewVehicleDTO> GetVehicles(VehicleFilter filter)
		{
			var vehicles = unitOfWork.Vehicles.GetAll();

			if (filter.MakeId.HasValue)
			{
				vehicles = vehicles.Where(v => v.Model.MakeId == filter.MakeId);
			}
			if (filter.ModelId.HasValue)
			{
				vehicles = vehicles.Where(v => v.ModelId == filter.ModelId);
			}

			switch(filter.SortBy)
			{
				case "id":
					vehicles = SortVehicles(vehicles, v => v.Id, filter.IsSortAscending);
					break;
				case "make":
					vehicles = SortVehicles(vehicles, v => v.Model.Make.Name, filter.IsSortAscending);
					break;
				case "model":
					vehicles = SortVehicles(vehicles, v => v.Model.Name, filter.IsSortAscending);
					break;
				case "contactName":
					vehicles = SortVehicles(vehicles, v => v.Contact.Name, filter.IsSortAscending);
					break;
			}

			if (filter.PageSize <= 0)
			{
				filter.PageSize = 10;
			}
			if (filter.Page <= 0)
			{
				filter.Page = 1;
			}

			QueryResult<ViewVehicleDTO> result = new QueryResult<ViewVehicleDTO>();
			result.TotalItems = vehicles.Count();

			vehicles = vehicles.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);

			result.Items = mapper.Map<IEnumerable<ViewVehicleDTO>>(vehicles);

			return result;
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

		private IEnumerable<Vehicle> SortVehicles(IEnumerable<Vehicle> vehicles,
			Func<Vehicle, object> keySelector, bool isSortAscending)
		{
			if (isSortAscending)
			{
				return vehicles.OrderBy(keySelector);
			}
			else
			{
				return vehicles.OrderByDescending(keySelector);
			}
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

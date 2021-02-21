using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vega.BLL.BusinessModels.Filters;
using Vega.BLL.BusinessModels.Shared;
using Vega.BLL.DTO.VehicleModels;
using Vega.BLL.Interfaces;
using Vega.DAL.Entity;
using Vega.DAL.Interfaces;

namespace Vega.BLL.Services
{
	public class VehicleService : IVehicleService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IRepository<Vehicle> vehicleRepository;
		private readonly IMapper mapper;

		public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			vehicleRepository = unitOfWork.Vehicles;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<ViewVehicleDTO>> GetVehiclesAsync()
		{
			var vehicles = await vehicleRepository.GetAllAsync();
			return mapper.Map<IEnumerable<ViewVehicleDTO>>(vehicles);
		}

		public async Task<ViewVehicleDTO> GetVehicleAsync(int id)
		{
			var vehicle = await vehicleRepository.GetAsync(id);
			return mapper.Map<ViewVehicleDTO>(vehicle);
		}

		public async Task<QueryResult<ViewVehicleDTO>> GetVehiclesAsync(VehicleFilter filter)
		{
			IQueryable<Vehicle> query = FindVehicles(filter);

			IOrderedQueryable<Vehicle> orderedQuery;
			switch(filter.SortBy)
			{
				case "make":
					orderedQuery = SortVehicles(query, v => v.Model.Make.Name, filter.IsSortAscending);
					break;
				case "model":
					orderedQuery = SortVehicles(query, v => v.Model.Name, filter.IsSortAscending);
					break;
				case "contactName":
					orderedQuery = SortVehicles(query, v => v.Contact.Name, filter.IsSortAscending);
					break;
				default: //"id"
					orderedQuery = SortVehicles(query, v => v.Id, filter.IsSortAscending);
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
			result.TotalItems = orderedQuery.Count();

			query = orderedQuery.Skip(filter.SkipPagesQuantity).Take(filter.PageSize);

			var vehicles = await vehicleRepository.GetByQueryAsync(query);

			result.Items = mapper.Map<IEnumerable<ViewVehicleDTO>>(vehicles);

			return result;
		}

		public async Task CreateAsync(CreateUpdateVehicleDTO createUpdateVehicleDTO)
		{
			var vehicle = CreateUpdateVehicleToVehicle(createUpdateVehicleDTO);
			await vehicleRepository.CreateAsync(vehicle);
		}

		public async Task UpdateAsync(int id, CreateUpdateVehicleDTO createUpdateVehicleDTO)
		{
			var vehicle = CreateUpdateVehicleToVehicle(createUpdateVehicleDTO);
			vehicle.Id = id;
			await vehicleRepository.UpdateAsync(vehicle);
		}

		public async Task DeleteAsync(int id)
		{
			await vehicleRepository.DeleteAsync(id);
		}

		private IQueryable<Vehicle> FindVehicles(VehicleFilter filter)
		{
			IQueryable<Vehicle> query = null;

			if (filter.MakeId.HasValue)
			{
				query = vehicleRepository.FindBy(v => v.Model.MakeId == filter.MakeId);
			}
			else if (filter.ModelId.HasValue)
			{
				if (query == null)
				{
					query = vehicleRepository.FindBy(v => v.ModelId == filter.ModelId);
				}
				else
				{
					query = query.Where(v => v.ModelId == filter.ModelId);
				}
			}
			else
			{
				query = vehicleRepository.GetAll();
			}

			return query;
		}

		private IOrderedQueryable<Vehicle> SortVehicles(IQueryable<Vehicle> query,
			Expression<Func<Vehicle, object>> keySelector, bool isSortAscending)
		{
			if (isSortAscending)
			{
				return query.OrderBy(keySelector);
			}
			else
			{
				return query.OrderByDescending(keySelector);
			}
		}

		private Vehicle CreateUpdateVehicleToVehicle(CreateUpdateVehicleDTO createUpdateVehicleDTO)
		{
			var vehicle = mapper.Map<Vehicle>(createUpdateVehicleDTO);

			vehicle.Features = createUpdateVehicleDTO.Features
				.Select(f => unitOfWork.Features.GetAsync(f).Result)
				.ToList();

			vehicle.LastUpdate = DateTime.Now;
			return vehicle;
		}
	}
}

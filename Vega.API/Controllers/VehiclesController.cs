using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Vega.BLL.BusinessModels;
using Vega.BLL.DTO.VehicleModels;
using Vega.BLL.Interfaces;

namespace Vega.API.Controllers
{
	[Route("api/vehicles")]
	[ApiController]
	public class VehiclesController : ControllerBase
	{
		private readonly IVehicleService vehiclesService;

		public VehiclesController(IVehicleService vehiclesService)
		{
			this.vehiclesService = vehiclesService;
		}

		[HttpGet("{id}")]
		public IActionResult GetVehicle(int id)
		{
			var vehicle = vehiclesService.GetVehicle(id);
			if (vehicle != null)
			{
				return Ok(vehicle);
			}

			return NoContent();
		}

		[HttpGet]
		public IActionResult GetVehicles([FromQuery] VehicleFilter filter)
		{
			var vehicles = vehiclesService.GetVehicles(filter);
			if (vehicles.TotalItems > 0)
			{
				return Ok(vehicles);
			}

			return NoContent();
		}


		[HttpPost]
		public IActionResult CreateVehicles([FromBody] CreateUpdateVehicleDTO vehicle)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			vehiclesService.Insert(vehicle);

			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateVehicle(int id, [FromBody] CreateUpdateVehicleDTO vehicle)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			vehiclesService.Update(id, vehicle);

			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteVehicle(int id)
		{
			vehiclesService.Delete(id);
			return Ok();
		}
	}
}

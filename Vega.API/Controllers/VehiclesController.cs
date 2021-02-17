using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

		[HttpGet]
		public async Task<IActionResult> GetVehiclesAsync([FromQuery] VehicleFilter filter)
		{
			var vehicles = await vehiclesService.GetVehiclesAsync(filter);

			if (vehicles.TotalItems > 0)
			{
				return Ok(vehicles);
			}

			return NoContent();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetVehicleAsync(int id)
		{
			var vehicle = await vehiclesService.GetVehicleAsync(id);

			if (vehicle != null)
			{
				return Ok(vehicle);
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> CreateVehiclesAsync([FromBody] CreateUpdateVehicleDTO vehicle)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await vehiclesService.CreateAsync(vehicle);

			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateVehicleAsync(int id, [FromBody] CreateUpdateVehicleDTO vehicle)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await vehiclesService.UpdateAsync(id, vehicle);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteVehicleAsync(int id)
		{
			await vehiclesService.DeleteAsync(id);

			return Ok();
		}
	}
}

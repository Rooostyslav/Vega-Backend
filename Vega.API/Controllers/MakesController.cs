using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Vega.BLL.Interfaces;

namespace Vega.API.Controllers
{
	[Route("api/makes")]
	[ApiController]
	public class MakesController : ControllerBase
	{
		private readonly IMakeService makeService;

		public MakesController(IMakeService makeService)
		{
			this.makeService = makeService;
		}

		[HttpGet]
		public IActionResult GetMakes()
		{
			var makes = makeService.GetMakes();
			if (makes.Count() > 0)
			{
				return Ok(makes.ToList());
			}

			return NoContent();
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
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
		public async Task<IActionResult> GetMakesAsync()
		{
			var makes = await makeService.GetMakesAsync();

			if (makes.Count() > 0)
			{
				return Ok(makes);
			}

			return NoContent();
		}
	}
}

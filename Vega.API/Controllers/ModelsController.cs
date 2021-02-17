using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vega.BLL.DTO;
using Vega.BLL.Interfaces;

namespace Vega.API.Controllers
{
	[Route("api/models")]
	[ApiController]
	public class ModelsController : ControllerBase
	{
		private readonly IModelService modelService;

		public ModelsController(IModelService modelService)
		{
			this.modelService = modelService;
		}

		[HttpGet]
		public async Task<IActionResult> GetModelsAsync()
		{
			var models = await modelService.GetModelsAsync();

			if (models.Count() > 0)
			{
				return Ok(models);
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> CreateContactAsync([FromBody] ModelDTO model)
		{
			if (ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await modelService.CreateAsync(model);

			return Ok();
		}
	}
}

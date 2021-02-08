using System.Linq;
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
		public IActionResult GetModels()
		{
			var models = modelService.GetModels();
			if (models.Count() > 0)
			{
				return Ok(models);
			}

			return NoContent();
		}

		[HttpPost]
		public IActionResult CreateContact([FromBody] ModelDTO model)
		{
			modelService.Insert(model);

			return Ok();
		}
	}
}

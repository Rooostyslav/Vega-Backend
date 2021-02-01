using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vega.BLL.Interfaces;

namespace Vega.API.Controllers
{
	[Route("api/features")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IFeatureService featureService;
		public FeaturesController(IFeatureService featureService)
		{
			this.featureService = featureService;
		}

		[HttpGet]
		public IActionResult GetFeatures()
		{
			var features = featureService.GetFeatures();
			if (features.Count() > 0)
			{
				return Ok(features);
			}
			
			return NoContent();
		}
	}
}

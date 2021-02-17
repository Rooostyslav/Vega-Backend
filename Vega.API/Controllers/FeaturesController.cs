using System.Linq;
using System.Threading.Tasks;
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
		public async Task<IActionResult> GetFeaturesAsync()
		{
			var features = await featureService.GetFeaturesAsync();

			if (features.Count() > 0)
			{
				return Ok(features);
			}
			
			return NoContent();
		}
	}
}

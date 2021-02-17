using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.BLL.DTO;

namespace Vega.BLL.Interfaces
{
	public interface IFeatureService : ICUDService<FeatureDTO>
	{
		Task<IEnumerable<FeatureDTO>> GetFeaturesAsync();

		Task<FeatureDTO> GetFeatureAsync(int id);
	}
}

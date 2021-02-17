using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.BLL.DTO;

namespace Vega.BLL.Interfaces
{
	public interface IModelService : ICUDService<ModelDTO>
	{
		Task<IEnumerable<ModelDTO>> GetModelsAsync();

		Task<ModelDTO> GetModelAsync(int id);
	}
}

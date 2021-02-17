using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.BLL.DTO;

namespace Vega.BLL.Interfaces
{
	public interface IMakeService : ICUDService<MakeDTO>
	{
		Task<IEnumerable<MakeDTO>> GetMakesAsync();

		Task<MakeDTO> GetMakeAsync(int id);
	}
}

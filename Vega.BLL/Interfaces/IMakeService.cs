using System.Collections.Generic;
using Vega.BLL.DTO;

namespace Vega.BLL.Interfaces
{
	public interface IMakeService
	{
		void Insert(MakeDTO makekDTO);
		void Update(MakeDTO makekDTO);
		void Delete(int id);
		MakeDTO GetMake(int id);
		IEnumerable<MakeDTO> GetMakes();
	}
}

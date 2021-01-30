using System.Collections.Generic;
using Vega.BLL.DTO;

namespace Vega.BLL.Interfaces
{
	public interface IModelService
	{
		void Insert(ModelDTO modelDTO);
		void Update(ModelDTO modelDTO);
		void Delete(int id);
		ModelDTO GetModel(int id);
		IEnumerable<ModelDTO> GetModels();
	}
}

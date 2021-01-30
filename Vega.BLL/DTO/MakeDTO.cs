using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.BLL.DTO
{
	public class MakeDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<ModelDTO> Models { get; set; }

		public MakeDTO()
		{
			Models = new Collection<ModelDTO>();
		}
	}
}

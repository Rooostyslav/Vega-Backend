using System.Collections.Generic;

namespace Vega.BLL.BusinessModels.Shared
{
	public class QueryResult<T>
	{
		public IEnumerable<T> Items { get; set; }

		public int TotalItems { get; set; }
	}
}

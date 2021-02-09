using System.Collections.Generic;

namespace Vega.BLL.BusinessModels
{
	public class QueryResult<T>
	{
		public IEnumerable<T> Items { get; set; }

		public int TotalItems { get; set; }
	}
}

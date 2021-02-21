
namespace Vega.BLL.BusinessModels.Filters
{
	public abstract class BaseFilter
	{
		public string SortBy { get; set; }

		public bool IsSortAscending { get; set; }

		public int Page { get; set; }

		public byte PageSize { get; set; }

		public int SkipPagesQuantity
		{
			get
			{
				return (Page - 1) * PageSize;
			}
		}
	}
}

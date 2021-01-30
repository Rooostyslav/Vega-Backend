using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.DAL.Entity
{
	[Table("Features")]
	public class Feature
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }
	}
}

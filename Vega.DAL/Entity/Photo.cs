using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.DAL.Entity
{
	[Table("Photos")]
	public class Photo
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string FileName { get; set; }

		public int VehicleId { get; set; }

		public Vehicle Vehicle { get; set; }
	}
}

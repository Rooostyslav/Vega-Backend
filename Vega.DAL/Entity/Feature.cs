using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.DAL.Entity
{
	[Table("Features")]
	public class Feature
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public ICollection<Vehicle> Vehicles { get; set; }

		public Feature()
		{
			Vehicles = new Collection<Vehicle>();
		}
	}
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.DAL.Entity
{
	[Table("Contacts")]
	public class Contact
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[StringLength(255)]
		public string Phone { get; set; }

		[Required]
		[StringLength(255)]
		public string Email { get; set; }

		public ICollection<Vehicle> Vehicles { get; set; }

		public Contact()
		{
			Vehicles = new Collection<Vehicle>();
		}
	}
}

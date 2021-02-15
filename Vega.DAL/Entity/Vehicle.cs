using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Vega.DAL.Entity
{
	[Table("Vehicles")]
	public class Vehicle
	{
		[Key]
		public int Id { get; set; }

		public int ModelId { get; set; }

		public Model Model { get; set; }

		public int ContactId { get; set; }

		public Contact Contact { get; set; }

		public bool IsRegistered { get; set; }

		public DateTime LastUpdate { get; set; }

		public ICollection<Feature> Features { get; set; }

		public ICollection<Photo> Photos { get; set; }

		public Vehicle()
		{
			Features = new Collection<Feature>();
			Photos = new Collection<Photo>();
		}
	}
}

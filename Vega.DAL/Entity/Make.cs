using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.DAL.Entity
{
	[Table("Makes")]
	public class Make
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public ICollection<Model> Models { get; set; }

		public Make()
		{
			Models = new Collection<Model>();
		}
	}
}

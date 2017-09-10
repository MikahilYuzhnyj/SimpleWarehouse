using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Product: AbstractEntity, IEntity
	{
		[ Required ]
		[ MaxLength( 100 ) ]
		public string Sku{ get; set; }

		[ Required ]
		[ MaxLength( 100 ) ]
		public string Code{ get; set; }

		[ Required ]
		public string Title{ get; set; }

		[ Required ]
		public bool Description{ get; set; }

		public decimal? Width{ get; set; }

		public decimal? SizeL{ get; set; }

		public decimal? SizeH{ get; set; }

		public decimal? SizeW{ get; set; }

		public decimal? Cost{ get; set; }
	}
}
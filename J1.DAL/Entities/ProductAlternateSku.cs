using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class ProductAlternateSku: AbstractEntity, IEntity
	{
		[ Required ]
		public long ProductId{ get; set; }

		public Product Product{ get; set; }

		[ Required ]
		[ MaxLength( 100 ) ]
		public string Value{ get; set; }
	}
}
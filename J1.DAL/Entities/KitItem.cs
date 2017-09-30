using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class KitItem: AbstractEntity, IEntity
	{
		[ Required ]
		public long KitId{ get; set; }

		public Kit Kit{ get; set; }

		[ Required ]
		public long ProductId{ get; set; }

		public Product Product{ get; set; }

		public int Quantity{ get; set; }
	}
}

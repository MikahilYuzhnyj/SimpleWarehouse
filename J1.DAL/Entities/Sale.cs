using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Sale: AbstractEntity, IEntity
	{
		[ Required ]
		[ MaxLength( 100 ) ]
		public string Code{ get; set; }

		[ Required ]
		public SaleStatusEnum SaleStatus{ get; set; }

		[ Required ]
		public long BuyerId{ get; set; }
		public Buyer Buyer { get; set; }

		[ Required ]
		public bool Description{ get; set; }
	}

	public enum SaleStatusEnum
	{
		Undefined = 0,
		Pending = 1,
		ReadyToShip = 2,
		Completed = 3,
		Cancelled = 4
	}
}
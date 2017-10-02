using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class SaleShipment: AbstractTenantEntity, ITenantEntity
	{
		[ Required ]
		public long SaleId{ get; set; }

		public Sale Sale{ get; set; }

		[ Required ]
		public string TrackingNumber{ get; set; }

		[ Required ]
		public string Address{ get; set; }

		[ Required ]
		public decimal Cost{ get; set; }

		[ Required ]
		public ShipmentStatusEnum ShipmentStatus{ get; set; }
	}

	public enum ShipmentStatusEnum
	{
		Undefined = 0
	}
}
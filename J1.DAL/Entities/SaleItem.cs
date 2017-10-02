using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class SaleItem: AbstractTenantEntity, ITenantEntity
	{
		[ Required ]
		public long SaleId{ get; set; }

		public Sale Sale{ get; set; }

		[ Required ]
		public long ProductId{ get; set; }

		public Product Product{ get; set; }

		[ Required ]
		public int Quantity{ get; set; }

		[ Required ]
		public decimal CostPerOne{ get; set; }
	}
}
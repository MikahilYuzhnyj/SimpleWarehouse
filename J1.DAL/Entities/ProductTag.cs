using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class ProductTag: AbstractTenantEntity, ITenantEntity
	{
		[ Required ]
		public long ProductId{ get; set; }

		public Product Product{ get; set; }

		[ Required ]
		public long TagId{ get; set; }

		public Tag Tag{ get; set; }
	}
}

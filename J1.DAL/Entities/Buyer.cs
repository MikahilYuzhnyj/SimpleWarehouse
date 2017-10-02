using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Buyer: AbstractTenantEntity, ITenantEntity
	{
		[ Required ]
		public string Name{ get; set; }

		[ Required ]
		public string Phone{ get; set; }
		
		public string Address{ get; set; }

		public string Email{ get; set; }

		public string CreditCard{ get; set; }
	}
}
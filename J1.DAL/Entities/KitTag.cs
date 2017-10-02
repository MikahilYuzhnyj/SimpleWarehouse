using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class KitTag: AbstractTenantEntity, ITenantEntity
	{
		[ Required ]
		public long KitId{ get; set; }

		public Kit Kit{ get; set; }

		[ Required ]
		public long TagId{ get; set; }

		public Tag Tag{ get; set; }
	}
}

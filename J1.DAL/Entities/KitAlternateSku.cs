using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class KitAlternateSku: AbstractTenantEntity, ITenantEntity
	{
		[ Required ]
		public long KitId{ get; set; }

		public Kit Kit{ get; set; }

		[ Required ]
		[ MaxLength( 100 ) ]
		public string Value{ get; set; }
	}
}
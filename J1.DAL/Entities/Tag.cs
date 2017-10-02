using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Tag: AbstractTenantEntity, ITenantEntity
	{
		[ Required ]
		[ MaxLength( 100 ) ]
		public string Value{ get; set; }
	}
}

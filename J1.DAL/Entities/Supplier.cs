using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Supplier: AbstractTenantEntity, ITenantEntity
	{
		[ Required ]
		public string Name{ get; set; }
	}
}
using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Brand: AbstractTenantEntity, ITenantEntity
	{
		[ Required ]
		public string Name{ get; set; }
	}
}
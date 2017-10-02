using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Classification: AbstractTenantEntity, ITenantEntity
	{
		[ Required ]
		public string Name{ get; set; }
	}
}
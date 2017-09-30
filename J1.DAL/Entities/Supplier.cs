using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Supplier: AbstractEntity, IEntity
	{
		[ Required ]
		public string Name{ get; set; }
	}
}
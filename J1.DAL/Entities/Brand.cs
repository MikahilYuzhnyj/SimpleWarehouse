using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Brand: AbstractEntity, IEntity
	{
		[ Required ]
		public string Name{ get; set; }
	}
}
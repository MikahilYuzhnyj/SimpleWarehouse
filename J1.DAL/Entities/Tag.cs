using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Tag: AbstractEntity, IEntity
	{
		[ Required ]
		[ MaxLength( 100 ) ]
		public string Value{ get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Classification: AbstractEntity, IEntity
	{
		[ Required ]
		public string Name{ get; set; }
	}
}
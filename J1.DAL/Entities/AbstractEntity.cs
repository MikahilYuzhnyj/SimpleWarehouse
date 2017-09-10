using System;
using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public interface IEntity
	{
		long Id{ get; set; }
	}

	public abstract class AbstractEntity
	{
		[ Key ]
		public long Id{ get; set; }
		
		[ Required ]
		public bool IsDeleted{ get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Tenant: AbstractEntity, IEntity
	{
		[ Required ]
		[ MaxLength( 100 ) ]
		public string Name{ get; set; }

		[ Required ]
		public string Phone{ get; set; }

		[ Required ]
		public string Address{ get; set; }

		[ Required ]
		public string Email{ get; set; }

		[ Required ]
		public bool IsActive{ get; set; }

		private Tenant()
		{
		}

		public Tenant( string name, string phone, string address, string email, bool isActive )
		{
			this.Name = name;
			this.Phone = phone;
			this.Address = address;
			this.Email = email;
			this.IsActive = isActive;
		}
	}
}
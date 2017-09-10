using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class User: AbstractEntity, IEntity
	{
		[ Required ]
		[ MaxLength( 100 ) ]
		public string Name{ get; set; }

		[ Required ]
		public string Email{ get; set; }

		[ Required ]
		public string Phone{ get; set; }

		[ Required ]
		public bool IsActive{ get; set; }

		[ Required ]
		public long TenantId{ get; set; }

		public Tenant Tenant{ get; set; }

		private User()
		{
		}

		public User( string name, string email, string phone, bool isActive, long tenantId )
		{
			this.Name = name;
			this.Email = email;
			this.Phone = phone;
			this.IsActive = isActive;
			this.TenantId = tenantId;
		}
	}
}
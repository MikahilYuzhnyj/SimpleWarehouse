using System;
using System.Linq;
using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public class UserRepository: GenericRepository< User >
	{
		public UserRepository( J1Context context )
			: base( context )
		{
		}

		public bool IsExistWithEmail( string userEmail )
		{
			return this.GetAll().Any( x => string.Equals( x.Email, userEmail, StringComparison.InvariantCultureIgnoreCase ) );
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using J1.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace J1.DAL.Repositories
{
	public class AuthRepository: IDisposable
	{
		private readonly J1Context _context;
		private readonly UserManager< IdentityUser > _userManager;

		public AuthRepository()
		{
			this._context = new J1Context();
			this._userManager = new UserManager< IdentityUser >( new UserStore< IdentityUser >( this._context ) );
		}

		public async Task< IdentityResult > RegisterUser( string userName, string password )
		{
			var user = new IdentityUser
			{
				UserName = userName
			};

			var result = await this._userManager.CreateAsync( user, password );

			return result;
		}

		public async Task< IdentityUser > FindUser( string userName, string password )
		{
			var user = await this._userManager.FindAsync( userName, password );

			return user;
		}
		
		public async Task< IdentityUser > FindAsync( UserLoginInfo loginInfo )
		{
			var user = await this._userManager.FindAsync( loginInfo );

			return user;
		}

		public async Task< IdentityResult > CreateAsync( IdentityUser user )
		{
			var result = await this._userManager.CreateAsync( user );

			return result;
		}

		public async Task< IdentityResult > AddLoginAsync( string userId, UserLoginInfo login )
		{
			var result = await this._userManager.AddLoginAsync( userId, login );

			return result;
		}

		public void Dispose()
		{
			this._context.Dispose();
			this._userManager.Dispose();
		}
	}
}
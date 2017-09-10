using J1.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace J1.DAL.Infrastructure
{
	public class ApplicationRoleManager: RoleManager< IdentityRole >
	{
		public ApplicationRoleManager( IRoleStore< IdentityRole, string > roleStore )
			: base( roleStore )
		{
		}

		public static ApplicationRoleManager Create( IdentityFactoryOptions< ApplicationRoleManager > options, IOwinContext context )
		{
			return new ApplicationRoleManager( new RoleStore< IdentityRole >( context.Get< J1Context >() ) );
		}
	}
}
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using J1.DAL.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace J1.API.Providers
{
	public class CustomOAuthProvider: OAuthAuthorizationServerProvider
	{
		public override Task ValidateClientAuthentication( OAuthValidateClientAuthenticationContext context )
		{
			context.Validated();
			return Task.FromResult< object >( null );
		}

		public override async Task GrantResourceOwnerCredentials( OAuthGrantResourceOwnerCredentialsContext context )
		{
			var allowedOrigin = "*";

			context.OwinContext.Response.Headers.Add( "Access-Control-Allow-Origin", new[] { allowedOrigin } );

			var userManager = context.OwinContext.GetUserManager< ApplicationUserManager >();

			var user = await userManager.FindAsync( context.UserName, context.Password );
			if( user == null )
			{
				context.SetError( "invalid_grant", "The user name or password is incorrect." );
				return;
			}

			var roles = user.Roles.ToList(); 

			var oAuthIdentity = await user.GenerateUserIdentityAsync( userManager, "JWT" );
			foreach( var role in roles )
			{
				oAuthIdentity.AddClaim( new Claim( ClaimTypes.Role, role.RoleId ) );
			}

			context.Validated( new AuthenticationTicket( oAuthIdentity, null ) );
		}
	}
}
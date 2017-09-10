using System;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using J1.API;
using J1.API.Providers;
using J1.DAL;
using J1.DAL.Infrastructure;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;

[ assembly : OwinStartup( typeof( Startup ) ) ]

namespace J1.API
{
	public class Startup
	{
		public static OAuthBearerAuthenticationOptions OAuthBearerOptions{ get; private set; }

		public void Configuration( IAppBuilder app )
		{
			var httpConfig = new HttpConfiguration();

			this.ConfigureOAuthTokenGeneration( app );
			this.ConfigureOAuthTokenConsumption( app );
			this.ConfigureWebApi( httpConfig );

			app.UseCors( CorsOptions.AllowAll );
			app.UseWebApi( httpConfig );
		}

		private void ConfigureOAuthTokenGeneration( IAppBuilder app )
		{
			// Configure the db context and user manager to use a single instance per request
			app.CreatePerOwinContext( J1Context.Create );
			app.CreatePerOwinContext< ApplicationUserManager >( ApplicationUserManager.Create );
			app.CreatePerOwinContext< ApplicationRoleManager >( ApplicationRoleManager.Create );

			var OAuthServerOptions = new OAuthAuthorizationServerOptions
			{
				//For Dev enviroment only (on production should be AllowInsecureHttp = false)
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString( "/token" ),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays( 1 ),
				Provider = new CustomOAuthProvider(),
				AccessTokenFormat = new CustomJwtFormat( "http://localhost:59822" )
			};

			// OAuth 2.0 Bearer Access Token Generation
			app.UseOAuthAuthorizationServer( OAuthServerOptions );
		}

		private void ConfigureOAuthTokenConsumption( IAppBuilder app )
		{
			var issuer = "http://localhost:59822";
			var audienceId = ConfigurationManager.AppSettings[ "as:AudienceId" ];
			var audienceSecret = TextEncodings.Base64Url.Decode( ConfigurationManager.AppSettings[ "as:AudienceSecret" ] );

			// Api controllers with an [Authorize] attribute will be validated with JWT
			app.UseJwtBearerAuthentication(
				new JwtBearerAuthenticationOptions
				{
					AuthenticationMode = AuthenticationMode.Active,
					AllowedAudiences = new[] { audienceId },
					IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
					{
						new SymmetricKeyIssuerSecurityTokenProvider( issuer, audienceSecret )
					}
				} );
		}

		private void ConfigureWebApi( HttpConfiguration config )
		{
			config.MapHttpAttributeRoutes();

			var jsonFormatter = config.Formatters.OfType< JsonMediaTypeFormatter >().First();
			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}
	}
}
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http.Routing;
using J1.DAL.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace J1.API.Factory
{
	public class ModelFactory
	{
		private readonly UrlHelper _UrlHelper;
		private readonly ApplicationUserManager _AppUserManager;

		public ModelFactory( HttpRequestMessage request, ApplicationUserManager appUserManager )
		{
			this._UrlHelper = new UrlHelper( request );
			this._AppUserManager = appUserManager;
		}

		public UserReturnModel Create( ApplicationUser appUser )
		{
			return new UserReturnModel
			{
				Url = this._UrlHelper.Link( "GetUserById", new { id = appUser.Id } ),
				Id = appUser.Id,
				UserName = appUser.UserName,
				Email = appUser.Email,
				EmailConfirmed = appUser.EmailConfirmed,
				JoinDate = appUser.JoinDate,
				Roles = this._AppUserManager.GetRolesAsync( appUser.Id ).Result,
				Claims = this._AppUserManager.GetClaimsAsync( appUser.Id ).Result
			};
		}

		public RoleReturnModel Create( IdentityRole appRole )
		{
			return new RoleReturnModel
			{
				Url = this._UrlHelper.Link( "GetRoleById", new { id = appRole.Id } ),
				Id = appRole.Id,
				Name = appRole.Name
			};
		}
	}

	public class UserReturnModel
	{
		public string Url{ get; set; }
		public string Id{ get; set; }
		public string UserName{ get; set; }
		public string Email{ get; set; }
		public bool EmailConfirmed{ get; set; }
		public DateTime JoinDate{ get; set; }
		public IList< string > Roles{ get; set; }
		public IList< Claim > Claims{ get; set; }
	}

	public class RoleReturnModel
	{
		public string Url{ get; set; }
		public string Id{ get; set; }
		public string Name{ get; set; }
	}
}
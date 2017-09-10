using System.Net.Http;
using System.Web.Http;
using J1.API.Factory;
using J1.API.Models.Session;
using J1.DAL.Infrastructure;
using J1.DAL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using J1.API.Exceptions;

namespace J1.API.Abstract
{
	public abstract class AbstractController: ApiController
	{
		protected readonly UnitOfWork _unitOfWork = new UnitOfWork();
		private ModelFactory _modelFactory;
		private readonly ApplicationUserManager _appUserManager = null;
		private readonly ApplicationRoleManager _appRoleManager = null;

		private UserSession UserSession
		{
			get
			{
				try
				{
					var applicationUserId = this.User.Identity.GetUserId();
					var userCache = HttpContext.Current.Cache[ applicationUserId ];
					if( userCache != null )
						return ( UserSession )userCache;

					var applicationUser = this.AppUserManager.FindById( applicationUserId );
					var tenant = this._unitOfWork.TenantRepository.GetById( applicationUser.TenantId );
					var user = this._unitOfWork.UserRepository.GetById( applicationUser.UserId );

					userCache = new UserSession( tenant.Id, tenant.Name, user.Id, user.Name );
					HttpContext.Current.Cache[ applicationUserId ] = userCache;

					return ( UserSession )userCache;
				}
				catch
				{
					throw new AuthenticateException();
				}
			}
		}

		protected TenantId TenantId => this.UserSession.TenantId;
		protected string TenantName => this.UserSession.TenantName.Value;
		protected UserId UserId => this.UserSession.UserId;
		protected string UserName => this.UserSession.UserName.Value;

		protected ApplicationUserManager AppUserManager
		{
			get { return this._appUserManager ?? this.Request.GetOwinContext().GetUserManager< ApplicationUserManager >(); }
		}

		protected ApplicationRoleManager AppRoleManager
		{
			get { return this._appRoleManager ?? this.Request.GetOwinContext().GetUserManager< ApplicationRoleManager >(); }
		}

		protected ModelFactory TheModelFactory
		{
			get
			{
				this._modelFactory = this._modelFactory ?? new ModelFactory( this.Request, this.AppUserManager );
				return this._modelFactory;
			}
		}

		protected IHttpActionResult ErrorResult( IdentityResult result )
		{
			if( result == null )
			{
				return this.InternalServerError();
			}

			if( !result.Succeeded )
			{
				if( result.Errors != null )
				{
					foreach( var error in result.Errors )
					{
						this.ModelState.AddModelError( "", error );
					}
				}

				if( this.ModelState.IsValid )
				{
					// No ModelState errors are available to send, so just return an empty BadRequest.
					return this.BadRequest();
				}

				return this.BadRequest( this.ModelState );
			}

			return null;
		}
	}
}

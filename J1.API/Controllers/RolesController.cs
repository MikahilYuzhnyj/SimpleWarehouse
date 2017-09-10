using System;
using System.Threading.Tasks;
using System.Web.Http;
using J1.API.Abstract;
using J1.API.Models.Roles;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace J1.API.Controllers
{
	[ RoutePrefix( "api/roles" ) ]
	public class RolesController: AbstractController
	{
		[ Route( "{id:guid}", Name = "GetRoleById" ) ]
		public async Task< IHttpActionResult > GetRole( string Id )
		{
			var role = await this.AppRoleManager.FindByIdAsync( Id );

			if( role != null )
			{
				return this.Ok( this.TheModelFactory.Create( role ) );
			}

			return this.NotFound();
		}

		[ Route( "", Name = "GetAllRoles" ) ]
		public IHttpActionResult GetAllRoles()
		{
			var roles = this.AppRoleManager.Roles;

			return this.Ok( roles );
		}

		[ Route( "create" ) ]
		public async Task< IHttpActionResult > Create( CreateRoleBindingModel model )
		{
			if( !this.ModelState.IsValid )
			{
				return this.BadRequest( this.ModelState );
			}

			var role = new IdentityRole { Name = model.Name };

			var result = await this.AppRoleManager.CreateAsync( role );

			if( !result.Succeeded )
			{
				return this.ErrorResult( result );
			}

			var locationHeader = new Uri( this.Url.Link( "GetRoleById", new { id = role.Id } ) );

			return this.Created( locationHeader, this.TheModelFactory.Create( role ) );
		}

		[ Route( "{id:guid}" ) ]
		public async Task< IHttpActionResult > DeleteRole( string Id )
		{
			var role = await this.AppRoleManager.FindByIdAsync( Id );

			if( role != null )
			{
				var result = await this.AppRoleManager.DeleteAsync( role );

				if( !result.Succeeded )
				{
					return this.ErrorResult( result );
				}

				return this.Ok();
			}

			return this.NotFound();
		}

		[ Route( "ManageUsersInRole" ) ]
		public async Task< IHttpActionResult > ManageUsersInRole( UsersInRoleModel model )
		{
			var role = await this.AppRoleManager.FindByIdAsync( model.Id );

			if( role == null )
			{
				this.ModelState.AddModelError( "", "Role does not exist" );
				return this.BadRequest( this.ModelState );
			}

			foreach( var user in model.EnrolledUsers )
			{
				var appUser = await this.AppUserManager.FindByIdAsync( user );

				if( appUser == null )
				{
					this.ModelState.AddModelError( "", string.Format( "User: {0} does not exists", user ) );
					continue;
				}

				if( !this.AppUserManager.IsInRole( user, role.Name ) )
				{
					var result = await this.AppUserManager.AddToRoleAsync( user, role.Name );

					if( !result.Succeeded )
					{
						this.ModelState.AddModelError( "", string.Format( "User: {0} could not be added to role", user ) );
					}
				}
			}

			foreach( var user in model.RemovedUsers )
			{
				var appUser = await this.AppUserManager.FindByIdAsync( user );

				if( appUser == null )
				{
					this.ModelState.AddModelError( "", string.Format( "User: {0} does not exists", user ) );
					continue;
				}

				var result = await this.AppUserManager.RemoveFromRoleAsync( user, role.Name );

				if( !result.Succeeded )
				{
					this.ModelState.AddModelError( "", string.Format( "User: {0} could not be removed from role", user ) );
				}
			}

			if( !this.ModelState.IsValid )
			{
				return this.BadRequest( this.ModelState );
			}

			return this.Ok();
		}
	}
}

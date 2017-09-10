using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using J1.API.Abstract;
using J1.API.Models;
using J1.DAL.Entities;
using J1.DAL.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace J1.API.Controllers
{
	[ RoutePrefix( "api/accounts" ) ]
	public class AccountsController: AbstractController
	{
		[ AllowAnonymous ]
		[ Route( "register" ) ]
		public async Task< IHttpActionResult > Register( RegisterBindingModel registerBindingModel )
		{
			if( !this.ModelState.IsValid )
				return this.BadRequest( this.ModelState );

			// Проверка на существование tenant
			var isExistTenant = this._unitOfWork.TenantRepository.IsExistWithName( registerBindingModel.TenantName );
			if( isExistTenant )
			{
				this.ModelState.AddModelError( "", "Такой арендатор уже существует" );
				return this.BadRequest( this.ModelState );
			}

			// Проверка на существование user
			var isExistUser = this._unitOfWork.UserRepository.IsExistWithEmail( registerBindingModel.Email );
			if( isExistUser )
			{
				this.ModelState.AddModelError( "", "Такой пользователь уже существует" );
				return this.BadRequest( this.ModelState );
			}

			// Добавляем tenant
			var tenant = new Tenant( registerBindingModel.TenantName, registerBindingModel.TenantPhone, registerBindingModel.TenantAddress, registerBindingModel.TenantEmail, true );
			tenant = this._unitOfWork.TenantRepository.Save( tenant );

			// Добавляем пользовательский аккаунт
			var user = new User( registerBindingModel.UserName, registerBindingModel.Email, registerBindingModel.Phone, true, tenant.Id );
			user = this._unitOfWork.UserRepository.Save( user );

			// Создаем Application User
			var appUser = new ApplicationUser
			{
				UserName = registerBindingModel.Email,
				Email = registerBindingModel.Email,
				TenantId = tenant.Id,
				UserId = user.Id,
				JoinDate = DateTime.Now.Date,
				EmailConfirmed = true
			};

			var addUserResult = await this.AppUserManager.CreateAsync( appUser, registerBindingModel.Password );
			if( !addUserResult.Succeeded )
			{
				this._unitOfWork.TenantRepository.Delete( tenant.Id );
				this._unitOfWork.UserRepository.Delete( user.Id );
				return this.ErrorResult( addUserResult );
			}

			// Добавляем роль администратора
			appUser = await this.AppUserManager.FindByEmailAsync( registerBindingModel.Email );

			var isExistRoleAdmin = await this.AppRoleManager.RoleExistsAsync( "Admin" );
			if( !isExistRoleAdmin )
				await this.AppRoleManager.CreateAsync( new IdentityRole( "Admin" ) );

			var addResult = await this.AppUserManager.AddToRolesAsync( appUser.Id, "Admin" );
			if( !addResult.Succeeded )
			{
				this.ModelState.AddModelError( "", "Не получилось добавить роль" );
				this._unitOfWork.TenantRepository.Delete( tenant.Id );
				this._unitOfWork.UserRepository.Delete( user.Id );
				return this.BadRequest( this.ModelState );
			}

			return this.Ok();
		}

		[ Authorize( Roles = "Admin" ) ]
		[ Route( "users" ) ]
		public IHttpActionResult GetUsers()
		{
			//Only SuperAdmin or Admin can delete users (Later when implement roles)
			var identity = this.User.Identity as ClaimsIdentity;

			return this.Ok( this.AppUserManager.Users.ToList().Select( u => this.TheModelFactory.Create( u ) ) );
		}

		[ Authorize( Roles = "Admin" ) ]
		[ Route( "user/{id:guid}", Name = "GetUserById" ) ]
		public async Task< IHttpActionResult > GetUser( string Id )
		{
			//Only SuperAdmin or Admin can delete users (Later when implement roles)
			var user = await this.AppUserManager.FindByIdAsync( Id );

			if( user != null )
			{
				return this.Ok( this.TheModelFactory.Create( user ) );
			}

			return this.NotFound();
		}

		[ Authorize( Roles = "Admin" ) ]
		[ Route( "user/{username}" ) ]
		public async Task< IHttpActionResult > GetUserByName( string username )
		{
			//Only SuperAdmin or Admin can delete users (Later when implement roles)
			var user = await this.AppUserManager.FindByNameAsync( username );

			if( user != null )
			{
				return this.Ok( this.TheModelFactory.Create( user ) );
			}

			return this.NotFound();
		}

		[ AllowAnonymous ]
		[ Route( "create" ) ]
		public async Task< IHttpActionResult > CreateUser( CreateUserBindingModel createUserModel )
		{
			if( !this.ModelState.IsValid )
			{
				return this.BadRequest( this.ModelState );
			}

			var user = new ApplicationUser
			{
				UserName = createUserModel.Username,
				Email = createUserModel.Email,
				JoinDate = DateTime.Now.Date
			};

			var addUserResult = await this.AppUserManager.CreateAsync( user, createUserModel.Password );

			if( !addUserResult.Succeeded )
			{
				return this.ErrorResult( addUserResult );
			}

			var code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync( user.Id );

			var callbackUrl = new Uri( this.Url.Link( "ConfirmEmailRoute", new { userId = user.Id, code } ) );

			await this.AppUserManager.SendEmailAsync( user.Id,
				"Confirm your account",
				"Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>" );

			var locationHeader = new Uri( this.Url.Link( "GetUserById", new { id = user.Id } ) );

			return this.Created( locationHeader, this.TheModelFactory.Create( user ) );
		}

		[ AllowAnonymous ]
		[ HttpGet ]
		[ Route( "ConfirmEmail", Name = "ConfirmEmailRoute" ) ]
		public async Task< IHttpActionResult > ConfirmEmail( string userId = "", string code = "" )
		{
			if( string.IsNullOrWhiteSpace( userId ) || string.IsNullOrWhiteSpace( code ) )
			{
				this.ModelState.AddModelError( "", "User Id and Code are required" );
				return this.BadRequest( this.ModelState );
			}

			var result = await this.AppUserManager.ConfirmEmailAsync( userId, code );

			if( result.Succeeded )
			{
				return this.Ok();
			}
			return this.ErrorResult( result );
		}

		[ Authorize ]
		[ Route( "ChangePassword" ) ]
		public async Task< IHttpActionResult > ChangePassword( ChangePasswordBindingModel model )
		{
			if( !this.ModelState.IsValid )
			{
				return this.BadRequest( this.ModelState );
			}

			var result = await this.AppUserManager.ChangePasswordAsync( this.User.Identity.GetUserId(), model.OldPassword, model.NewPassword );

			if( !result.Succeeded )
			{
				return this.ErrorResult( result );
			}

			return this.Ok();
		}

		[ Authorize( Roles = "Admin" ) ]
		[ Route( "user/{id:guid}" ) ]
		public async Task< IHttpActionResult > DeleteUser( string id )
		{
			//Only SuperAdmin or Admin can delete users (Later when implement roles)

			var appUser = await this.AppUserManager.FindByIdAsync( id );

			if( appUser != null )
			{
				var result = await this.AppUserManager.DeleteAsync( appUser );

				if( !result.Succeeded )
				{
					return this.ErrorResult( result );
				}

				return this.Ok();
			}

			return this.NotFound();
		}

		[ Authorize( Roles = "Admin" ) ]
		[ Route( "user/{id:guid}/roles" ) ]
		[ HttpPut ]
		public async Task< IHttpActionResult > AssignRolesToUser( [ FromUri ] string id, [ FromBody ] string[] rolesToAssign )
		{
			var appUser = await this.AppUserManager.FindByIdAsync( id );

			if( appUser == null )
			{
				return this.NotFound();
			}

			var currentRoles = await this.AppUserManager.GetRolesAsync( appUser.Id );

			var rolesNotExists = rolesToAssign.Except( this.AppRoleManager.Roles.Select( x => x.Name ) ).ToArray();

			if( rolesNotExists.Any() )
			{
				this.ModelState.AddModelError( "", string.Format( "Roles '{0}' does not exixts in the system", string.Join( ",", rolesNotExists ) ) );
				return this.BadRequest( this.ModelState );
			}

			var removeResult = await this.AppUserManager.RemoveFromRolesAsync( appUser.Id, currentRoles.ToArray() );

			if( !removeResult.Succeeded )
			{
				this.ModelState.AddModelError( "", "Failed to remove user roles" );
				return this.BadRequest( this.ModelState );
			}

			var addResult = await this.AppUserManager.AddToRolesAsync( appUser.Id, rolesToAssign );

			if( !addResult.Succeeded )
			{
				this.ModelState.AddModelError( "", "Failed to add user roles" );
				return this.BadRequest( this.ModelState );
			}

			return this.Ok();
		}

		//[ Authorize( Roles = "Admin" ) ]
		//[ Route( "user/{id:guid}/assignclaims" ) ]
		//[ HttpPut ]
		//public async Task< IHttpActionResult > AssignClaimsToUser( [ FromUri ] string id, [ FromBody ] List< ClaimBindingModel > claimsToAssign )
		//{
		//	if( !this.ModelState.IsValid )
		//	{
		//		return this.BadRequest( this.ModelState );
		//	}

		//	var appUser = await this.AppUserManager.FindByIdAsync( id );

		//	if( appUser == null )
		//	{
		//		return this.NotFound();
		//	}

		//	foreach( ClaimBindingModel claimModel in claimsToAssign )
		//	{
		//		if( appUser.Claims.Any( c => c.ClaimType == claimModel.Type ) )
		//		{
		//			await this.AppUserManager.RemoveClaimAsync( id, ExtendedClaimsProvider.CreateClaim( claimModel.Type, claimModel.Value ) );
		//		}

		//		await this.AppUserManager.AddClaimAsync( id, ExtendedClaimsProvider.CreateClaim( claimModel.Type, claimModel.Value ) );
		//	}

		//	return this.Ok();
		//}

		//[ Authorize( Roles = "Admin" ) ]
		//[ Route( "user/{id:guid}/removeclaims" ) ]
		//[ HttpPut ]
		//public async Task< IHttpActionResult > RemoveClaimsFromUser( [ FromUri ] string id, [ FromBody ] List< ClaimBindingModel > claimsToRemove )
		//{
		//	if( !this.ModelState.IsValid )
		//	{
		//		return this.BadRequest( this.ModelState );
		//	}

		//	var appUser = await this.AppUserManager.FindByIdAsync( id );

		//	if( appUser == null )
		//	{
		//		return this.NotFound();
		//	}

		//	foreach( ClaimBindingModel claimModel in claimsToRemove )
		//	{
		//		if( appUser.Claims.Any( c => c.ClaimType == claimModel.Type ) )
		//		{
		//			await this.AppUserManager.RemoveClaimAsync( id, ExtendedClaimsProvider.CreateClaim( claimModel.Type, claimModel.Value ) );
		//		}
		//	}

		//	return this.Ok();
		//}
	}
}
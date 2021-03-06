﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace J1.DAL.Infrastructure
{
	public class ApplicationUser: IdentityUser
	{
		[ Required ]
		public DateTime JoinDate{ get; set; }

		[ Required ]
		public long TenantId{ get; set; }

		[ Required ]
		public long UserId{ get; set; }

		public async Task< ClaimsIdentity > GenerateUserIdentityAsync( UserManager< ApplicationUser > manager, string authenticationType )
		{
			var userIdentity = await manager.CreateIdentityAsync( this, authenticationType );
			// Add custom user claims here

			return userIdentity;
		}
	}
}
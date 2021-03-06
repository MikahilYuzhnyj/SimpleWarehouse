﻿using System;
using System.Linq;
using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ITenantRepository: IGenericRepository< Tenant >
	{
		bool IsExistWithName( string tenantName );
	}

	internal class TenantRepository: GenericRepository< Tenant >, ITenantRepository
	{
		public TenantRepository( J1Context context )
			: base( context )
		{
		}

		public bool IsExistWithName( string tenantName )
		{
			return this.GetAll().Any( x => string.Equals( x.Name, tenantName, StringComparison.InvariantCultureIgnoreCase ) );
		}
	}
}

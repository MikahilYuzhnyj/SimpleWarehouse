using System;

namespace J1.DAL.Repositories
{
	public class UnitOfWork: IDisposable
	{
		private readonly J1Context context = new J1Context();
		private AuthRepository _authRepository;
		private TenantRepository _tenantRepository;
		private UserRepository _userRepository;
		
		public AuthRepository AuthRepository
		{
			get
			{
				if( this._authRepository == null )
				{
					this._authRepository = new AuthRepository();
				}
				return this._authRepository;
			}
		}

		public TenantRepository TenantRepository
		{
			get
			{
				this._tenantRepository = this._tenantRepository ?? new TenantRepository( this.context );
				return this._tenantRepository;
			}
		}

		public UserRepository UserRepository
		{
			get
			{
				this._userRepository = this._userRepository ?? new UserRepository( this.context );
				return this._userRepository;
			}
		}

		public void Save()
		{
			this.context.SaveChanges();
		}

		private bool disposed;

		protected virtual void Dispose( bool disposing )
		{
			if( !this.disposed )
			{
				if( disposing )
				{
					this.context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			this.Dispose( true );
			GC.SuppressFinalize( this );
		}
	}
}

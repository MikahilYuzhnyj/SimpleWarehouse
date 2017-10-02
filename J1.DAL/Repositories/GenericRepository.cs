using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using J1.DAL.Entities;

namespace J1.DAL.Repositories
{

	public interface IGenericRepository< TEntity > where TEntity : class, IEntity
	{
		IEnumerable< TEntity > GetAll();
		TEntity GetById( object id );
		TEntity Save( TEntity entity );
		void Delete( object id );
	}

	internal class GenericRepository< TEntity > where TEntity : class, IEntity
	{
		internal readonly J1Context context;
		internal readonly DbSet< TEntity > dbSet;

		protected GenericRepository( J1Context context )
		{
			this.context = context;
			this.dbSet = context.Set< TEntity >();
		}

		public virtual IEnumerable< TEntity > GetAll()
		{
			return this.dbSet;
		}
		
		public virtual TEntity GetById( object id )
		{
			return this.dbSet.Find( id );
		}

		public virtual TEntity Save( TEntity entity )
		{
			if( entity.Id > 0 )
			{
				this.dbSet.Attach( entity );
				this.context.Entry( entity ).State = EntityState.Modified;
			}
			else
			{
				entity = this.dbSet.Add( entity );
			}

			this.context.SaveChanges();
			return entity;
		}
		
		public virtual void Delete( object id )
		{
			var entityToDelete = this.dbSet.Find( id );
			this.Delete( entityToDelete );

			this.context.SaveChanges();
		}

		protected virtual void Delete( TEntity entityToDelete )
		{
			if( this.context.Entry( entityToDelete ).State == EntityState.Detached )
			{
				this.dbSet.Attach( entityToDelete );
			}
			this.dbSet.Remove( entityToDelete );
		}
	}
}

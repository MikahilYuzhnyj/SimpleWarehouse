using System.Collections.Generic;
using System.Linq;
using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IProductRepository: IGenericRepository< Product >
	{
		IEnumerable< Product > GetAll( int pageNumber, int pageSize );
	}

	internal class ProductRepository: GenericRepository< Product >, IProductRepository
	{
		public ProductRepository( J1Context context )
			: base( context )
		{
		}

		public IEnumerable< Product > GetAll( int pageNumber, int pageSize )
		{
			return this.GetAll()
				.Skip( pageSize * pageNumber )
				.Take( pageSize );
		}
	}
}

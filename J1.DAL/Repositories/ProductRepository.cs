using System.Collections.Generic;
using System.Linq;
using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IProductRepository: ITenantGenericRepository< Product >
	{
		IEnumerable< Product > GetAll( long tenantId, int pageNumber, int pageSize );
	}

	internal class ProductRepository: TenantGenericRepository< Product >, IProductRepository
	{
		public ProductRepository( J1Context context )
			: base( context )
		{
		}

		public IEnumerable< Product > GetAll( long tenantId, int pageNumber, int pageSize )
		{
			return this.GetAll( tenantId )
				.Skip( pageSize * pageNumber )
				.Take( pageSize );
		}
	}
}

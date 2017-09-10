using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public class ProductRepository: GenericRepository< Product >
	{
		public ProductRepository( J1Context context )
			: base( context )
		{
		}
	}
}

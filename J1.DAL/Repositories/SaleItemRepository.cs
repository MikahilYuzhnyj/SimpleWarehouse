using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public class SaleItemRepository: GenericRepository< SaleItem >
	{
		public SaleItemRepository( J1Context context )
			: base( context )
		{
		}
	}
}

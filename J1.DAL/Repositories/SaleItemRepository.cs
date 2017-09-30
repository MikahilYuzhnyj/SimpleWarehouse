using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ISaleItemRepository: IGenericRepository< SaleItem >
	{
	}

	internal class SaleItemRepository: GenericRepository< SaleItem >, ISaleItemRepository
	{
		public SaleItemRepository( J1Context context )
			: base( context )
		{
		}
	}
}

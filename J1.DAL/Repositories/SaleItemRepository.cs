using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ISaleItemRepository: ITenantGenericRepository< SaleItem >
	{
	}

	internal class SaleItemRepository: TenantGenericRepository< SaleItem >, ISaleItemRepository
	{
		public SaleItemRepository( J1Context context )
			: base( context )
		{
		}
	}
}

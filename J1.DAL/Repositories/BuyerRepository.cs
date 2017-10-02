using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IBuyerRepository: ITenantGenericRepository< Buyer >
	{
	}

	internal class BuyerRepository: TenantGenericRepository< Buyer >, IBuyerRepository
	{
		public BuyerRepository( J1Context context )
			: base( context )
		{
		}
	}
}

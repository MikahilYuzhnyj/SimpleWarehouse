using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IKitItemRepository: ITenantGenericRepository< KitItem >
	{
	}

	internal class KitItemRepository: TenantGenericRepository< KitItem >, IKitItemRepository
	{
		public KitItemRepository( J1Context context )
			: base( context )
		{
		}
	}
}

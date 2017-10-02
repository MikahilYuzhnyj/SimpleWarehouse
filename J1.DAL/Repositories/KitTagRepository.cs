using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IKitTagRepository: ITenantGenericRepository< KitTag >
	{
	}

	internal class KitTagRepository: TenantGenericRepository< KitTag >, IKitTagRepository
	{
		public KitTagRepository( J1Context context )
			: base( context )
		{
		}
	}
}

using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IKitAlternateSkuRepository: ITenantGenericRepository< KitAlternateSku >
	{
	}

	internal class KitAlternateSkuRepository: TenantGenericRepository< KitAlternateSku >, IKitAlternateSkuRepository
	{
		public KitAlternateSkuRepository( J1Context context )
			: base( context )
		{
		}
	}
}

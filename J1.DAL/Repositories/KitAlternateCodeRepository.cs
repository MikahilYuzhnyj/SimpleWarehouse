using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IKitAlternateCodeRepository: ITenantGenericRepository< KitAlternateCode >
	{
	}

	internal class KitAlternateCodeRepository: TenantGenericRepository< KitAlternateCode >, IKitAlternateCodeRepository
	{
		public KitAlternateCodeRepository( J1Context context )
			: base( context )
		{
		}
	}
}

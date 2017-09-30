using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IKitAlternateCodeRepository: IGenericRepository< KitAlternateCode >
	{
	}

	internal class KitAlternateCodeRepository: GenericRepository< KitAlternateCode >, IKitAlternateCodeRepository
	{
		public KitAlternateCodeRepository( J1Context context )
			: base( context )
		{
		}
	}
}

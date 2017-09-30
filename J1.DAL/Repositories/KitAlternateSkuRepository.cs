using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IKitAlternateSkuRepository: IGenericRepository< KitAlternateSku >
	{
	}

	internal class KitAlternateSkuRepository: GenericRepository< KitAlternateSku >, IKitAlternateSkuRepository
	{
		public KitAlternateSkuRepository( J1Context context )
			: base( context )
		{
		}
	}
}

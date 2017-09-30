using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IKitTagRepository: IGenericRepository< KitTag >
	{
	}

	internal class KitTagRepository: GenericRepository< KitTag >, IKitTagRepository
	{
		public KitTagRepository( J1Context context )
			: base( context )
		{
		}
	}
}

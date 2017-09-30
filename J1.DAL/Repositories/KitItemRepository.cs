using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IKitItemRepository: IGenericRepository< KitItem >
	{
	}

	internal class KitItemRepository: GenericRepository< KitItem >, IKitItemRepository
	{
		public KitItemRepository( J1Context context )
			: base( context )
		{
		}
	}
}

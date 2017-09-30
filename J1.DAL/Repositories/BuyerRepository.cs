using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IBuyerRepository: IGenericRepository< Buyer >
	{
	}

	internal class BuyerRepository: GenericRepository< Buyer >, IBuyerRepository
	{
		public BuyerRepository( J1Context context )
			: base( context )
		{
		}
	}
}

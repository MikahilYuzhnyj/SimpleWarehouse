using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public class BuyerRepository: GenericRepository< Buyer >
	{
		public BuyerRepository( J1Context context )
			: base( context )
		{
		}
	}
}

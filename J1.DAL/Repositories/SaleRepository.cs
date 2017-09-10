using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public class SaleRepository: GenericRepository< Sale >
	{
		public SaleRepository( J1Context context )
			: base( context )
		{
		}
	}
}

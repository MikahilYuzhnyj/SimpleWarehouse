using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ISaleRepository: IGenericRepository< Sale >
	{
	}

	internal class SaleRepository: GenericRepository< Sale >, ISaleRepository
	{
		public SaleRepository( J1Context context )
			: base( context )
		{
		}
	}
}

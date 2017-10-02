using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ISaleRepository: ITenantGenericRepository< Sale >
	{
	}

	internal class SaleRepository: TenantGenericRepository< Sale >, ISaleRepository
	{
		public SaleRepository( J1Context context )
			: base( context )
		{
		}
	}
}

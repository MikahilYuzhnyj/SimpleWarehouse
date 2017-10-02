using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IProductAlternateCodeRepository: ITenantGenericRepository< ProductAlternateCode >
	{
	}

	internal class ProductAlternateCodeRepository: TenantGenericRepository< ProductAlternateCode >, IProductAlternateCodeRepository
	{
		public ProductAlternateCodeRepository( J1Context context )
			: base( context )
		{
		}
	}
}

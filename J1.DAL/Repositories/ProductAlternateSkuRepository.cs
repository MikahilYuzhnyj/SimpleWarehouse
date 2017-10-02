using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IProductAlternateSkuRepository: ITenantGenericRepository< ProductAlternateSku >
	{
	}

	internal class ProductAlternateSkuRepository: TenantGenericRepository< ProductAlternateSku >, IProductAlternateSkuRepository
	{
		public ProductAlternateSkuRepository( J1Context context )
			: base( context )
		{
		}
	}
}

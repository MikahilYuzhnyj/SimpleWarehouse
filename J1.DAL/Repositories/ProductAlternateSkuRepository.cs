using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IProductAlternateSkuRepository: IGenericRepository< ProductAlternateSku >
	{
	}

	internal class ProductAlternateSkuRepository: GenericRepository< ProductAlternateSku >, IProductAlternateSkuRepository
	{
		public ProductAlternateSkuRepository( J1Context context )
			: base( context )
		{
		}
	}
}

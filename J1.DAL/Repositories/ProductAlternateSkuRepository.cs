using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public class ProductAlternateSkuRepository: GenericRepository< ProductAlternateSku >
	{
		public ProductAlternateSkuRepository( J1Context context )
			: base( context )
		{
		}
	}
}

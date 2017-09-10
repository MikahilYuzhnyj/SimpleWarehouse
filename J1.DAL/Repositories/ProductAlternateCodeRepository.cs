using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public class ProductAlternateCodeRepository: GenericRepository< ProductAlternateCode >
	{
		public ProductAlternateCodeRepository( J1Context context )
			: base( context )
		{
		}
	}
}

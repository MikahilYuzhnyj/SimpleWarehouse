using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IProductAlternateCodeRepository: IGenericRepository< ProductAlternateCode >
	{
	}

	internal class ProductAlternateCodeRepository: GenericRepository< ProductAlternateCode >, IProductAlternateCodeRepository
	{
		public ProductAlternateCodeRepository( J1Context context )
			: base( context )
		{
		}
	}
}

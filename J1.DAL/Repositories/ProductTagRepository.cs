using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IProductTagRepository: IGenericRepository< ProductTag >
	{
	}

	internal class ProductTagRepository: GenericRepository< ProductTag >, IProductTagRepository
	{
		public ProductTagRepository( J1Context context )
			: base( context )
		{
		}
	}
}

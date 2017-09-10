using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public class ProductTagRepository: GenericRepository< ProductTag >
	{
		public ProductTagRepository( J1Context context )
			: base( context )
		{
		}
	}
}

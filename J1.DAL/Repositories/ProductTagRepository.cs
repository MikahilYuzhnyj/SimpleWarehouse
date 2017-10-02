using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IProductTagRepository: ITenantGenericRepository< ProductTag >
	{
	}

	internal class ProductTagRepository: TenantGenericRepository< ProductTag >, IProductTagRepository
	{
		public ProductTagRepository( J1Context context )
			: base( context )
		{
		}
	}
}

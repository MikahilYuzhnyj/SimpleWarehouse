using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IBrandRepository: ITenantGenericRepository< Brand >
	{
	}

	internal class BrandRepository: TenantGenericRepository< Brand >, IBrandRepository
	{
		public BrandRepository( J1Context context )
			: base( context )
		{
		}
	}
}

using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IBrandRepository: IGenericRepository< Brand >
	{
	}

	internal class BrandRepository: GenericRepository< Brand >, IBrandRepository
	{
		public BrandRepository( J1Context context )
			: base( context )
		{
		}
	}
}

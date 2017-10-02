using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IClassificationRepository: ITenantGenericRepository< Classification >
	{
	}

	internal class ClassificationRepository: TenantGenericRepository< Classification >, IClassificationRepository
	{
		public ClassificationRepository( J1Context context )
			: base( context )
		{
		}
	}
}

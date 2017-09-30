using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface IClassificationRepository: IGenericRepository< Classification >
	{
	}

	internal class ClassificationRepository: GenericRepository< Classification >, IClassificationRepository
	{
		public ClassificationRepository( J1Context context )
			: base( context )
		{
		}
	}
}

using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public class TagRepository: GenericRepository< Tag >
	{
		public TagRepository( J1Context context )
			: base( context )
		{
		}
	}
}

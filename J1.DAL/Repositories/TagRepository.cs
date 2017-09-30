using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ITagRepository: IGenericRepository< Tag >
	{
	}

	internal class TagRepository: GenericRepository< Tag >, ITagRepository
	{
		public TagRepository( J1Context context )
			: base( context )
		{
		}
	}
}

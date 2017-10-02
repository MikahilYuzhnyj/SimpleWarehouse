using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ITagRepository: ITenantGenericRepository< Tag >
	{
	}

	internal class TagRepository: TenantGenericRepository< Tag >, ITagRepository
	{
		public TagRepository( J1Context context )
			: base( context )
		{
		}
	}
}

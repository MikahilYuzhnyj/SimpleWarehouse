using System.Collections.Generic;
using System.Linq;
using J1.DAL.Entities;

namespace J1.DAL.Repositories
{

	public interface IKitRepository: IGenericRepository< Kit >
	{
		IEnumerable< Kit > GetAll( int pageNumber, int pageSize );
	}

	internal class KitRepository: GenericRepository< Kit >, IKitRepository
	{
		public KitRepository( J1Context context )
			: base( context )
		{
		}

		public IEnumerable< Kit > GetAll( int pageNumber, int pageSize )
		{
			return this.GetAll()
				.Skip( pageSize * pageNumber )
				.Take( pageSize );
		}
	}
}

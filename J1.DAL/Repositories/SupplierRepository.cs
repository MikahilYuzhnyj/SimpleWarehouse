using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ISupplierRepository: IGenericRepository< Supplier >
	{
	}

	internal class SupplierRepository: GenericRepository< Supplier >, ISupplierRepository
	{
		public SupplierRepository( J1Context context )
			: base( context )
		{
		}
	}
}

using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ISupplierRepository: ITenantGenericRepository< Supplier >
	{
	}

	internal class SupplierRepository: TenantGenericRepository< Supplier >, ISupplierRepository
	{
		public SupplierRepository( J1Context context )
			: base( context )
		{
		}
	}
}

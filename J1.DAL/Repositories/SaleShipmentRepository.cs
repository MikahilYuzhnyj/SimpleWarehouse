using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ISaleShipmentRepository: ITenantGenericRepository< SaleShipment >
	{
	}

	internal class SaleShipmentRepository: TenantGenericRepository< SaleShipment >, ISaleShipmentRepository
	{
		public SaleShipmentRepository( J1Context context )
			: base( context )
		{
		}
	}
}

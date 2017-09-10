using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public class SaleShipmentRepository: GenericRepository< SaleShipment >
	{
		public SaleShipmentRepository( J1Context context )
			: base( context )
		{
		}
	}
}

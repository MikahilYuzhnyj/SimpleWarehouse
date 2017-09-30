using J1.DAL.Entities;

namespace J1.DAL.Repositories
{
	public interface ISaleShipmentRepository: IGenericRepository< SaleShipment >
	{
	}

	internal class SaleShipmentRepository: GenericRepository< SaleShipment >, ISaleShipmentRepository
	{
		public SaleShipmentRepository( J1Context context )
			: base( context )
		{
		}
	}
}

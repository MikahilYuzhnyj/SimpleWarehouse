using System.ComponentModel.DataAnnotations;

namespace J1.DAL.Entities
{
	public class Kit: AbstractEntity, IEntity
	{
		[ Required ]
		[ MaxLength( 100 ) ]
		public string Sku{ get; set; }

		[ Required ]
		[ MaxLength( 100 ) ]
		public string Code{ get; set; }

		[ Required ]
		public string Title{ get; set; }

		[ Required ]
		public string Description{ get; set; }

		public int Weight { get; set; }

		public decimal SizeL{ get; set; }

		public decimal SizeH{ get; set; }

		public decimal SizeW{ get; set; }

		/// <summary>
		/// Закупочная цена
		/// </summary>
		public decimal Cost{ get; set; }

		/// <summary>
		/// Розничная цена
		/// </summary>
		public decimal RetailPrice { get; set; }

		/// <summary>
		/// Цена для продажи
		/// </summary>
		public decimal SalePrice { get; set; }
	}
}
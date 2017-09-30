using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J1.DAL.Entities;

namespace J1.API.Models.Products
{
	public class ProductModel
	{
		public string Sku{ get; set; }
		public string Code{ get; set; }
		public string Title{ get; set; }
		public string Description{ get; set; }
		public int? Weight{ get; set; }
		public decimal? SizeL{ get; set; }
		public decimal? SizeH{ get; set; }
		public decimal? SizeW{ get; set; }

		public long BrandId{ get; set; }
		public long ClassificationId{ get; set; }
		public long SupplierId{ get; set; }

		public decimal? Cost{ get; set; }
		public decimal? RetailPrice{ get; set; }
		public decimal? SalePrice{ get; set; }
	}

	public class ProductItemModel
	{
		public string Sku{ get; set; }
		public string Code{ get; set; }
		public string Title{ get; set; }

		public string ClassificationName{ get; set; }
		public string SupplierName{ get; set; }
		public string Tags{ get; set; }

		public decimal? Cost{ get; set; }
		public string Url{ get; set; }

		public int OnHand{ get; set; }
		public int Pending{ get; set; }
		public int Available{ get; set; }

		private ProductItemModel() {}

		public ProductItemModel( Product product, IEnumerable< ProductTag > productTags )
		{
			this.Sku = product.Sku;
			this.Code = product.Code;
			this.Title = product.Title;
			this.ClassificationName = product.Classification.Name;
			this.SupplierName = product.Supplier.Name;
			this.Tags = string.Join( ", ", productTags.Select( x => x.Tag.Value ) );
			this.Cost = product.Cost;

			this.Url = string.Empty;
			this.OnHand = 0;
			this.Pending = 0;
			this.Available = 0;
		}
	}
}
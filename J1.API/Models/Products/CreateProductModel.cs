using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J1.DAL.Entities;

namespace J1.API.Models.Products
{
	public class CreateProductModel
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
}
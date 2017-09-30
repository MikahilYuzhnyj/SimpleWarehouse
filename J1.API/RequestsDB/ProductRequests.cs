using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using J1.API.Models.Products;
using J1.DAL.Repositories;

namespace J1.API.RequestsDB
{
	public static class ProductRequests
	{
		public static List< ProductItemModel > GetProductsForCatalog(
			IProductRepository productRepo, IProductTagRepository productTagRepo,
			int pageNumber, int pageSize
			)
		{
			var products = productRepo.GetAll( pageNumber, pageSize );
			var productTags = productTagRepo.GetAll();
			var joinProducts = ( from product in products
				join productTag in productTags on product.Id equals productTag.ProductId
				select new { Product = product, ProductTag = productTag } )
				.ToList()
				.GroupBy( x => x.Product )
				.Select( x => new ProductItemModel( x.Key, x.Select( t => t.ProductTag ) ) )
				.ToList();

			return joinProducts;
		}
	}
}
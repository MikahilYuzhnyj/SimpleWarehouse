using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using J1.API.Abstract;
using J1.API.Models.Products;
using J1.API.RequestsDB;
using Microsoft.AspNet.Identity;

namespace J1.API.Controllers
{
	[ Authorize ]
	[ RoutePrefix( "api/Products" ) ]
	public class ProductsController: AbstractController
	{
		[ HttpGet ]
		[ Route( "list" ) ]
		public IHttpActionResult List( int pageNumber = 0, int pageSize = 10 )
		{
			return this.Ok( ProductRequests.GetProductsForCatalog(
				this._unitOfWork.ProductRepository,
				this._unitOfWork.ProductTagRepository,
				this.TenantId,
				pageNumber,
				pageSize
				) );
		}

		[ HttpGet ]
		[ Route( "getBrands" ) ]
		public IHttpActionResult GetBrands()
		{
			var brands = this._unitOfWork.BrandRepository.GetAll().Select( x => new BrandModel( x.Id, x.Name ) ).ToList();
			return this.Ok( brands );
		}

		[ HttpGet ]
		[ Route( "getClassifications" ) ]
		public IHttpActionResult GetClassifications()
		{
			var classifications = this._unitOfWork.ClassificationRepository.GetAll().Select( x => new ClassificationModel( x.Id, x.Name ) ).ToList();
			return this.Ok( classifications );
		}

		[ HttpGet ]
		[ Route( "getSuppliers" ) ]
		public IHttpActionResult GetSuppliers()
		{
			var suppliers = this._unitOfWork.SupplierRepository.GetAll().Select( x => new SupplierModel( x.Id, x.Name ) ).ToList();
			return this.Ok( suppliers );
		}

		[ HttpPost ]
		[ Route( "Create" ) ]
		public IHttpActionResult Create( CreateProductModel model ) {
			return this.Ok();
		}
	}
}

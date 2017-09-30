using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using J1.API.Abstract;
using J1.API.RequestsDB;
using Microsoft.AspNet.Identity;

namespace J1.API.Controllers
{
	[ RoutePrefix( "api/Products" ) ]
	public class ProductsController: AbstractController
	{
		[ Authorize ]
		[ Route( "" ) ]
		public IHttpActionResult List( int pageNumber = 0, int pageSize = 10 )
		{
			return Ok( ProductRequests.GetProductsForCatalog(
				this._unitOfWork.ProductRepository,
				this._unitOfWork.ProductTagRepository,
				pageNumber,
				pageSize
				) );
		}
	}
}

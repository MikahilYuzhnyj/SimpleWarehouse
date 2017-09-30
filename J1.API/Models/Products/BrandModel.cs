using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace J1.API.Models.Products
{
	public class BrandModel
	{
		public long Id{ get; set; }
		public string Name{ get; set; }

		public BrandModel( long id, string name )
		{
			this.Id = id;
			this.Name = name;
		}
	}
}
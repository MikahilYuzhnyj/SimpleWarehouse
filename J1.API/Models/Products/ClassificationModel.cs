using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace J1.API.Models.Products
{
	public class ClassificationModel
	{
		public long Id{ get; set; }
		public string Name{ get; set; }

		public ClassificationModel( long id, string name )
		{
			this.Id = id;
			this.Name = name;
		}
	}
}